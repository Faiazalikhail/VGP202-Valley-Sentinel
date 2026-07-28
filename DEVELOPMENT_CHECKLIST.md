# Valley Sentinel - Development Checklist

Checkboxes marked `[x]` are complete in the project-setup stage. Gameplay work remains unchecked.

## Phase 1: Project Setup

- [x] Confirm the workspace was empty before creating files.
- [x] Use Unity 6000.3.9f1 and the official 3D cross-platform URP template.
- [x] Confirm URP and New Input System packages are in the manifest.
- [x] Confirm Android Build Support is installed.
- [x] Create the `Assets/_Project` folder structure.
- [x] Set Company Name to Alikhail Games.
- [x] Set Product Name to Valley Sentinel.
- [x] Set Android package identifier to `com.alikhailgames.endlessdefender`.
- [x] Configure landscape-only orientation.
- [x] Configure ARM64 and IL2CPP for Android.
- [x] Create an empty `DefencePrototype` scene.
- [x] Make `DefencePrototype` the enabled build scene.
- [x] Add a Unity `.gitignore`.
- [x] Open/import the project once in Unity and confirm successful compilation.
- [x] Switch the active build platform/target to Android.
- [ ] Make a blank development Build and Run to the Samsung phone.

## Phase 2: Mobile Input

- [x] Create `ValleySentinelInput.inputactions` with Gameplay and UI action maps.
- [ ] Add Canvas and Input System UI Input Module.
- [ ] Add a right-side On-Screen Stick bound to Aim.
- [ ] Add left-side Fire and Reload On-Screen Buttons.
- [ ] Add Pause button.
- [ ] Hide/disable Switch Weapon and Special buttons for MVP.
- [ ] Respect the Android safe area.
- [ ] Implement a small `InputReader` using action callbacks.
- [ ] Test simultaneous right-stick aim and left-button press on device.
- [ ] Add sensitivity and invert-Y settings only after base aim works.

## Phase 3: Turret Aiming

- [ ] Build `TurretYaw > WeaponPitch > Camera/Weapon` hierarchy.
- [ ] Implement horizontal rotation from Aim X.
- [ ] Implement vertical pitch from Aim Y.
- [ ] Clamp yaw and pitch to the intended arc.
- [ ] Apply delta time and sensitivity consistently.
- [ ] Confirm no movement controls exist.
- [ ] Test small, medium, and maximum joystick input.
- [ ] Test aim response on the target phone at 60 FPS.

## Phase 4: Weapon Firing

- [ ] Create `WeaponData` ScriptableObject type.
- [ ] Create one Standard Machine Gun data asset.
- [ ] Implement raycast firing.
- [ ] Enforce fire rate.
- [ ] Add magazine and reserve ammunition.
- [ ] Implement manual reload and correct ammo transfer.
- [ ] Block fire during reload.
- [ ] Add simple pooled muzzle/impact feedback.
- [ ] Add basic shot, reload, and empty feedback.
- [ ] Test that ammunition never becomes negative or duplicates.

## Phase 5: Enemy Prototype

- [ ] Create `EnemyData` ScriptableObject type.
- [ ] Create one Basic Infantry data asset.
- [ ] Create a simple enemy prefab with collider.
- [ ] Move toward one attack point using a simple route.
- [ ] Stop at attack range.
- [ ] Fire at the defence on a timer.
- [ ] Receive weapon damage and die.
- [ ] Raise defeated event and return to pool.
- [ ] Avoid advanced AI, cover search, and squad logic.

## Phase 6: Shield and Health

- [ ] Implement maximum/current shield and health.
- [ ] Apply resistance and shield damage multiplier.
- [ ] Route damage through shield before health.
- [ ] Add shield-hit, low-shield, and shield-break feedback.
- [ ] Add delayed health regeneration.
- [ ] Stop regeneration when damage is received.
- [ ] Clamp all values.
- [ ] Trigger game over exactly once at zero health.

## Phase 7: Infinite Waves

- [ ] Create wave budget formula.
- [ ] Select enemies by cost, minimum wave, and weight.
- [ ] Add spawn groups and delays.
- [ ] Track active enemies and wave completion.
- [ ] Add every-5 and every-10 milestone flags.
- [ ] Reserve every-20 transition hook without building multiple maps.
- [ ] Cap active enemies and minimum spawn delay.
- [ ] Confirm the system continues beyond wave 20 with no final wave.
- [ ] Add object pooling for infantry.

## Phase 8: Score and UI

- [ ] Display current wave.
- [ ] Display kills and defence score.
- [ ] Display frontline distance and survival time.
- [ ] Display shield and health.
- [ ] Display magazine/reserve and reload status.
- [ ] Add a simple score multiplier or document its later phase.
- [ ] Add Defence Rating on results.
- [ ] Update values through events or controlled intervals.
- [ ] Confirm all values reset on restart.

## Phase 9: Supply Drop

- [ ] Create one simple blue crate prefab.
- [ ] Add visible parachute/descent behaviour.
- [ ] Announce drop with colour and message.
- [ ] Allow the machine gun to damage/open the crate.
- [ ] Apply one implemented useful reward.
- [ ] Prevent duplicate rewards.
- [ ] Despawn the crate if it reaches the ground.
- [ ] Pool the crate.
- [ ] Leave red crate unimplemented.

## Phase 10: Android Test

- [ ] Enable USB debugging and accept the RSA prompt.
- [ ] Confirm Unity detects the Samsung device.
- [ ] Build and Run a development APK.
- [ ] Confirm landscape orientation.
- [ ] Confirm touch controls and safe area.
- [ ] Profile CPU, GPU, memory, and frame pacing.
- [ ] Run for at least ten minutes.
- [ ] Test pause/resume and Android focus changes.
- [ ] Save a known-good APK as a demonstration backup.

## Phase 11: GDD Completion

- [x] Complete all 44 requested GDD sections.
- [x] Add a clear infinite-runner justification.
- [x] Add controls, player mechanics, weapons, items, environment, and enemies.
- [x] Add class/object architecture.
- [x] Add ten pseudocode examples.
- [x] Add six Mermaid flowcharts.
- [x] Add asset research with licence and cost tracking.
- [ ] Replace placeholder balance values with playtest notes if the prototype changes them.
- [ ] Proofread against the instructor's exact rubric and course naming.

## Phase 12: Submission Preparation

- [ ] Confirm whether the course code is VGP202 or VGC202 on the official assignment sheet.
- [x] Use the requested PDF filename `VGC202_A1_Alikhail_Mohammad.pdf`.
- [x] Format the generated PDF as 12-point, single-spaced body text.
- [ ] Confirm student number/section requirements and add them if required.
- [ ] Open the final PDF and inspect every page.
- [ ] Confirm headings, tables, pseudocode, and flowcharts are readable.
- [ ] Confirm no unfinished-feature claim appears as completed work.
- [ ] Back up the Unity project, PDF, and known-good APK.
- [ ] Submit only the files required by the instructor.

## Scope Lock

Do not begin vehicles, aircraft, red crates, special weapons, multiple maps, permanent upgrades, or multiplayer until every MVP item through Phase 10 is complete and stable on the phone.
