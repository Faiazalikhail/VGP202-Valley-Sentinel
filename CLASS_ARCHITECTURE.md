# Valley Sentinel - Class Architecture

This document describes planned classes. None of these gameplay classes is implemented during the project-setup stage.

## Architecture Principles

- One class should have one clear responsibility.
- ScriptableObjects store reusable design data; MonoBehaviours store scene and runtime state.
- Systems communicate through explicit references, C# events, or small interfaces.
- Frequently spawned objects are pooled.
- UI reads state through events and display methods; it does not decide gameplay.
- Avoid runtime scene searches and avoid a separate `Update` loop on every simple object where a manager or coroutine can schedule the work.

## Planned Class Summary

| Class | Type | Responsibility | Important collaborators |
|---|---|---|---|
| GameManager | MonoBehaviour | Run state, start/end/restart, survival time | PlayerDefence, WaveManager, ScoreManager, UIManager |
| InputReader | MonoBehaviour | Input action callbacks and public input state/events | PlayerTurretController, WeaponController, UI pause |
| PlayerTurretController | MonoBehaviour | Yaw, pitch, clamps, sensitivity | InputReader |
| WeaponController | MonoBehaviour | Fire timing, raycast/projectile request, ammo, reload, feedback | WeaponData, InputReader, ObjectPool, AudioManager |
| WeaponData | ScriptableObject | Static weapon values and effectiveness | WeaponController |
| PlayerDefence | MonoBehaviour | Shield, health, damage, regeneration, death | GameManager, UIManager, AudioManager |
| EnemyBase | MonoBehaviour | Enemy runtime health, movement state, attack timing, death | EnemyData, PlayerDefence, ScoreManager, ObjectPool |
| EnemyData | ScriptableObject | Enemy stats, armour, score, wave cost, eligibility | EnemyBase, WaveManager |
| EnemySpawner | MonoBehaviour | Spawn-zone choice and pooled enemy activation | WaveManager, ObjectPool, EnemyData |
| WaveManager | MonoBehaviour | Budget, enemy list, milestones, wave completion | EnemySpawner, EnemyData, GameManager, UIManager |
| ObjectPool | Generic service/MonoBehaviour | Reuse GameObjects safely | Spawner, weapons, supplies, VFX |
| SupplyDropManager | MonoBehaviour | Supply timing, route, crate type | SupplyCrate, ObjectPool, WaveManager |
| SupplyCrate | MonoBehaviour | Descent, damage, opening, reward/danger request | SupplyDropManager, PlayerDefence, WeaponController, WaveManager |
| ScoreManager | MonoBehaviour | Kills, defence score, combo, rating, progress | EnemyBase, WaveManager, SupplyCrate, UIManager |
| UIManager | MonoBehaviour | HUD and panels | All state-owning systems |
| AudioManager | MonoBehaviour | Pooled/limited sound playback | Weapons, defence, enemies, UI |

## Data Objects

### WeaponData fields

```text
displayName
weaponCategory
damage
fireRate
magazineSize
reserveAmmunition
reloadDuration
projectileSpeed
accuracySpread
heatPerShot
recoil
targetEffectivenessCategory
hitMask
```

The first Standard Machine Gun asset is the only required prototype weapon. Heavy machine gun, anti-air cannon, and explosive launcher assets can be created later using the same type.

### EnemyData fields

```text
displayName
maximumHealth
baseDamage
movementSpeed
attackRange
attackDelay
accuracy
scoreValue
armourType
targetPriority
waveCost
minimumWave
selectionWeight
prefab
```

Only Basic Infantry is required for the first prototype. Variants reference different EnemyData assets rather than duplicated scripts.

### Planned wave modifier data

```text
minimumWave
healthMultiplier
damageMultiplier
speedMultiplier
spawnDelayMultiplier
accuracyMultiplier
allowedDirections
formationBias
```

This may remain calculated in `WaveManager` for the MVP. A `WaveModifierData` ScriptableObject should only be introduced if designers need multiple authored progression curves.

## Player Defence Contract

Planned serialized variables:

```text
maximumShield
currentShield
maximumHealth
currentHealth
shieldDamageMultiplier
healthRegenerationDelay
healthRegenerationRate
incomingDamageResistance
```

Public behaviour:

```text
ApplyDamage(amount, damageType)
RestoreShield(amount)
RestoreHealth(amount)
IncreaseMaximumShield(amount)
IncreaseMaximumHealth(amount)
ResetDefence()
```

Events:

```text
ShieldChanged(current, maximum)
HealthChanged(current, maximum)
ShieldBroken()
DefenceDestroyed()
```

The class records the last damage time. Health regeneration begins only when shield is empty or damaged as designed, health is below maximum, and the delay has passed. Incoming damage resistance is clamped so it cannot create negative damage.

## State Models

### Game state

```text
Booting -> Ready -> Running -> Paused -> Running
                         \-> GameOver -> Restarting -> Running
```

### Weapon state

```text
Ready -> Firing -> Cooldown -> Ready
Ready -> Reloading -> Ready
Firing/Cooldown -> Empty -> Reloading
```

Reloading blocks firing. Switching weapons is disabled during the MVP and later either cancels reload safely or keeps per-weapon reload state, based on testing.

### Enemy state

```text
InactivePool -> Advancing -> AtAttackPosition -> Attacking -> Dead -> InactivePool
```

The Basic Infantry enemy does not need advanced AI. A short list of waypoints or a direct movement target is enough.

## Key Interfaces

Small interfaces may be used when they reduce coupling:

```text
IDamageable
  ApplyDamage(DamageInfo damage)

IPoolable
  OnTakenFromPool()
  OnReturnedToPool()

IRewardReceiver
  AddAmmunition(amount)
  RestoreShield(amount)
  RestoreHealth(amount)
```

Do not add interfaces only to make the architecture look larger. Introduce them when at least two classes need the contract.

## Event Flow Examples

### Enemy defeated

1. Weapon hit calls `EnemyBase.ApplyDamage`.
2. Enemy health reaches zero.
3. Enemy raises a defeated event with its score value.
4. `ScoreManager` adds kill, score, combo, and progress.
5. `WaveManager` decreases the active-enemy count.
6. `EnemyBase` resets and returns to its pool.
7. UI updates through ScoreManager and WaveManager events.

### Player defeated

1. Enemy attack calls `PlayerDefence.ApplyDamage`.
2. Shield absorbs damage, then remaining damage affects health.
3. Health reaches zero and `DefenceDestroyed` fires once.
4. `GameManager` changes state to GameOver and stops wave spawning.
5. InputReader disables the Gameplay map.
6. UIManager shows final statistics and Restart.

## Avoiding Large Managers

`GameManager` must not calculate weapon damage, choose enemies, update every HUD label, or play individual sounds. Those jobs remain with their owning classes. Its valid data is limited to game state, survival time, pause state, and references needed to begin or end a run.

## Unity Object Plan

| GameObject or prefab | Components planned |
|---|---|
| PlayerDefencePosition | PlayerDefence, turret child transforms |
| MachineGun | WeaponController, muzzle transform, audio source/feedback references |
| BasicInfantry | EnemyBase, Animator, simple collider, pooled identity |
| BlueSupplyCrate | SupplyCrate, descent component or simple movement, collider |
| Systems | One focused component per child object or clearly grouped service root |
| HUD Canvas | UIManager plus references to bars, labels, and buttons |
| On-screen controls | OnScreenStick and OnScreenButton components from Input System |

## Assembly Plan

Assembly definitions are optional for the MVP. If compile times or test separation become useful, create:

- `ValleySentinel.Runtime`
- `ValleySentinel.Tests`

Do not create a large assembly graph during the first prototype.
