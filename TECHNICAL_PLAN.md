# Valley Sentinel - Technical Plan

## 1. Technical Goal

Build a small, stable Android prototype in Unity 6.3 LTS that proves four things: stationary turret aiming works on touch, one weapon and one enemy can interact, shield and health can end a run, and the budget system can generate waves without a fixed ending. Every later feature must fit around that core without forcing a rewrite.

## 2. Current Baseline

| Area | Current state |
|---|---|
| Editor | Unity 6000.3.9f1 |
| Template | Official 3D cross-platform template |
| Rendering | URP 17.0.1; mobile and PC pipeline assets included |
| Input | Input System 1.17.0 in manifest; project set to New Input System |
| Android module | Installed, including SDK, NDK, OpenJDK |
| Scene | Empty `DefencePrototype` camera-and-light scene |
| Code | None added |
| External assets | None imported |

The template also contains packages not required by the first prototype, such as Visual Scripting, Timeline, Version Control, and AI Navigation. They are not a current problem, but package removal should wait until after the first successful editor open and Android test.

## 3. Safe Unity Settings

Already configured:

- Company Name: Alikhail Games.
- Product Name: Valley Sentinel.
- Android application identifier: `com.alikhailgames.endlessdefender`.
- Landscape orientation with portrait autorotation disabled.
- 1920 x 1080 standalone preview size.
- ARM64 target architecture.
- IL2CPP scripting backend for Android.
- New Input System only.
- `DefencePrototype` as the enabled build scene.
- Android as the active Unity build target.
- Mobile URP quality profile from the official template.
- No post-processing in the prototype scene camera.

Still to verify in the Unity editor before the first phone build:

- Confirm the Mobile quality level is selected for Android.
- Confirm Graphics APIs on the Samsung device; start with the template defaults and only change after a device test.
- Set the runtime target frame rate to 60 later from the bootstrap/game settings code.
- Confirm minimum Android API against the connected phone and course submission rule.
- Create a development keystore only if the class workflow requires a signed APK beyond Unity's debug signing.

## 4. Scene Plan

| Scene | Purpose | Prototype status |
|---|---|---|
| Bootstrap | Persistent services and first scene selection | Planned; not needed for first interaction test |
| MainMenu | Start, settings, credits | Planned |
| DefencePrototype | All first playable gameplay | Created, empty baseline |
| GameOver | Results and restart | Planned; initially may be a panel in DefencePrototype |

For the MVP, a Game Over panel inside `DefencePrototype` is cheaper and safer than a scene transition. The separate scene remains a future architecture option.

## 5. Input System Plan

Asset: `Assets/_Project/Settings/ValleySentinelInput.inputactions`

### Gameplay map

| Action | Type | Planned control |
|---|---|---|
| Aim | Value / Vector2 | Right On-Screen Stick using `<Gamepad>/rightStick` |
| Fire | Button | Left On-Screen Button using a virtual gamepad control |
| Reload | Button | Left On-Screen Button |
| SwitchWeapon | Button | Left On-Screen Button; disabled or hidden in MVP |
| SpecialWeapon | Button | Left On-Screen Button; disabled or hidden in MVP |
| Pause | Button | Top-corner button |

### UI map

Navigate, Submit, Cancel, Point, and Click are present for Unity UI. Touch position and touch press are bound for Point and Click.

The `InputReader` will subscribe to action callbacks and expose read-only state/events. Gameplay classes will not call `Input.GetTouch` and will not know which physical control generated an action.

## 6. Data-Driven Design

`WeaponData`, `EnemyData`, and later `UpgradeData` are ScriptableObjects. Runtime classes hold changing state such as current ammunition or health; data assets hold designer values such as damage, fire rate, wave cost, and minimum wave.

Benefits for this assignment:

- Infantry variants can share one `EnemyBase` implementation.
- Values can be balanced without editing code.
- Future weapons fit the same controller.
- Wave selection reads cost and eligibility directly from data.

No ScriptableObject asset is created until the class using it exists, which avoids unused configuration files in the setup stage.

## 7. Runtime Ownership

Keep managers focused:

- `GameManager` owns run state and survival time, not weapons or enemies.
- `WaveManager` owns wave planning and completion.
- `EnemySpawner` converts a spawn request into a pooled enemy instance.
- `ScoreManager` owns score calculations and rating.
- `UIManager` displays values supplied by other systems.
- `AudioManager` plays requested clips without deciding gameplay.

References will be assigned in prefabs/scenes or through explicit initialization. Avoid `FindObjectOfType` during play.

## 8. Prototype Object Hierarchy

```text
DefencePrototype
  Environment
  PlayerDefencePosition
    TurretYaw
      WeaponPitch
        MainCamera
        MachineGun
          MuzzlePoint
  SpawnZones
    ValleyFloor
    MountainPath
  Systems
    GameManager
    WaveManager
    EnemySpawner
    ScoreManager
    SupplyDropManager
    AudioManager
  Pools
    InfantryPool
    ImpactPool
    SupplyCratePool
  Canvas
    HUD
    RightAimStick
    LeftActionButtons
    PausePanel
    GameOverPanel
  EventSystem
```

Only objects needed by the current development phase should be added.

## 9. Wave Algorithm

Each `EnemyData` contains `waveCost`, `minimumWave`, and selection weight. The manager calculates:

```text
budget = baseBudget
       + waveNumber * difficultyGrowth
       + survivalSeconds * timeMultiplier
```

The manager repeatedly selects an eligible enemy whose cost fits the remaining budget. It stops when nothing affordable remains. Integer or long counters are acceptable for normal play, but calculations should clamp multipliers and spawn rates to safe practical limits so an extremely long run cannot overflow or request thousands of simultaneous objects.

Every 5th wave modifies the selection weights toward a mixed formation. Every 10th wave adds a major-assault modifier. Every 20th wave schedules an environment transition. These modifiers change composition and timing, not only health.

## 10. Object Pooling

Pools will be used for enemies, projectiles if chosen, bullet impacts, muzzle flashes, and crates. A generic pool may be introduced after the infantry loop works. For the first gun, raycasts are preferred over physical bullets because they reduce physics cost and are easier to validate on mobile. Projectile speed remains in `WeaponData` for future weapons.

Pool rules:

- Prewarm a measured amount, not the maximum imaginable wave.
- Grow in small increments if exhausted.
- Reset health, timers, subscriptions, and visual state on reuse.
- Return objects when dead, out of range, or after their effect finishes.
- Never leave returned objects subscribed to global events.

## 11. Mobile Performance Budget

Target: stable 60 FPS on Samsung Galaxy A26 5G in a short classroom demonstration.

| Area | Initial limit or approach |
|---|---|
| Active infantry | Start near 10-20; measure before raising |
| Materials | Reuse a small palette and atlas where practical |
| Real-time lights | One main directional light; no per-enemy lights |
| Shadows | Main light only; short distance; disable on distant enemies if needed |
| Post-processing | Off for MVP |
| Physics | Simple colliders; raycast weapon; fixed timestep unchanged until measured |
| UI | Avoid layout rebuilds every frame; update text only when values change |
| Animation | One simple humanoid controller; no complex IK |
| Spawning | Pool frequently created objects |
| Terrain | Simple meshes and distant background cards/low-detail meshes |

Optimization will follow profiler evidence. Visual quality will be reduced before core readability or input responsiveness.

## 12. Implementation Order

1. Open and import the project once in Unity 6000.3.9f1.
2. Switch to Android and make a blank development build to the connected phone.
3. Add Canvas, right On-Screen Stick, Fire, Reload, and Pause controls.
4. Implement `InputReader` and test action values without gameplay.
5. Add turret yaw/pitch hierarchy and clamped aim.
6. Add one raycast machine gun and ammunition/reload.
7. Add one infantry enemy with a simple path and attack position.
8. Add defence shield, health, delayed regeneration, and game over.
9. Add endless budget waves and pooling.
10. Add score/HUD and one blue supply crate.
11. Profile on the target phone and fix the largest measured cost.
12. Prepare the final classroom and assignment builds.

## 13. Android Classroom Connection Checklist

- Charge the Samsung phone above 50%.
- Enable Developer Options and USB debugging.
- Use a data-capable USB cable.
- Accept the phone's RSA debugging prompt.
- In Unity, switch platform to Android before class.
- Make one development APK/build-and-run test before class.
- Keep a known-good APK on the laptop as backup.
- Keep the Unity project closed during transport so no import is interrupted.

## 14. Technical Definition of Done for the Setup Stage

- Project opens in Unity 6000.3.9f1 with no compile errors.
- URP mobile renderer is active.
- `DefencePrototype` opens and is the enabled build scene.
- Input-actions asset imports without errors.
- Android build target can be selected.
- Folder structure and all required documents exist.
- No gameplay C# scripts or external assets have been added.
