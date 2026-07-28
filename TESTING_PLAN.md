# Valley Sentinel - Testing Plan

## 1. Purpose

Testing must prove that the small Android prototype is controllable, logically correct, repeatable after restart, and stable on the Samsung Galaxy A26 5G. Advanced planned features are not test targets until implemented.

## 2. Test Environments

| Environment | Use |
|---|---|
| Unity Editor 6000.3.9f1 | Fast functional checks with keyboard/mouse bindings |
| Device Simulator/Game view | Layout and aspect-ratio preview only |
| Samsung Galaxy A26 5G | Final input, frame rate, safe area, audio, thermal, and build checks |
| Development Android build | Profiler connection and logs |
| Non-development Android build | Final performance confirmation later |

## 3. Setup-Stage Verification

| ID | Test | Expected result |
|---|---|---|
| SET-01 | Open project in Unity 6000.3.9f1 | Import completes with no compile or serialization errors |
| SET-02 | Inspect Graphics/Quality | Mobile URP pipeline is available and selected for Android |
| SET-03 | Open DefencePrototype | Scene contains a camera and directional light; no missing scripts |
| SET-04 | Inspect Player settings | Company, product, package ID, landscape, ARM64, IL2CPP, and Input System match plan |
| SET-05 | Open input-actions asset | Gameplay and UI maps import and display all planned actions |
| SET-06 | Open Build Profiles/Settings | DefencePrototype is the enabled scene |
| SET-07 | Blank Build and Run | App opens on the connected phone in landscape |

## 4. Mobile Input Tests

| ID | Test | Expected result |
|---|---|---|
| IN-01 | Move right aim stick horizontally | Turret yaw changes smoothly in the same direction |
| IN-02 | Move right aim stick vertically | Weapon pitch changes and stays inside clamp |
| IN-03 | Release aim stick | Rotation stops; aim angle remains |
| IN-04 | Hold Fire while aiming | Both touches work at the same time |
| IN-05 | Press Reload while right thumb remains on stick | Reload action is received without dropping aim input |
| IN-06 | Touch outside controls | No firing, reload, or movement occurs |
| IN-07 | Rotate/tilt device physically | Game remains in supported landscape orientation |
| IN-08 | Pause and resume | Gameplay actions stop while paused and restore once |
| IN-09 | Safe-area check | No required button or label is clipped or under a system cutout |

## 5. Turret and Weapon Tests

| ID | Test | Expected result |
|---|---|---|
| WPN-01 | Hold maximum aim for five seconds | Yaw/pitch stop at configured limits without jitter |
| WPN-02 | Hold Fire with full magazine | Shots match configured fire rate and ammo decreases once per shot |
| WPN-03 | Fire with empty magazine | No damage raycast; limited empty feedback plays |
| WPN-04 | Reload partially empty magazine | Only required rounds move from reserve |
| WPN-05 | Reload with insufficient reserve | Remaining reserve moves; reserve reaches zero; magazine is partly filled |
| WPN-06 | Reload full magazine | Reload does not start |
| WPN-07 | Press Fire during reload | No shot occurs until reload completes |
| WPN-08 | Repeated reload input | One reload process only; no ammo duplication |
| WPN-09 | Hit enemy collider | Correct damage applies and hit feedback appears |
| WPN-10 | Miss enemy | No enemy damage applies; shot is still counted for accuracy |

## 6. Enemy Tests

| ID | Test | Expected result |
|---|---|---|
| EN-01 | Spawn Basic Infantry | It activates at a valid zone with full health |
| EN-02 | Let enemy advance | It reaches and stops at its attack position |
| EN-03 | Let enemy attack | Defence takes configured damage at configured delay |
| EN-04 | Deal lethal damage | Enemy dies once, adds one kill/score, and returns to pool |
| EN-05 | Reuse pooled enemy | Health, attack timer, transform, animation, and event state are reset |
| EN-06 | End run with active enemy | Enemy cannot continue damaging results/restart state |

## 7. Shield and Health Tests

| ID | Test | Expected result |
|---|---|---|
| DEF-01 | Damage smaller than shield | Shield decreases; health remains unchanged |
| DEF-02 | Damage larger than remaining shield | Shield reaches zero and leftover damage reduces health |
| DEF-03 | Apply resistance | Final damage equals the clamped resistance calculation |
| DEF-04 | Wait less than regeneration delay | Health does not regenerate |
| DEF-05 | Wait beyond regeneration delay | Health rises at the configured rate and stops at maximum |
| DEF-06 | Take damage during regeneration | Regeneration stops and delay restarts |
| DEF-07 | Reach zero health | One game-over event occurs and gameplay input/spawning stop |
| DEF-08 | Restore shield/health | Values clamp to maximum and UI matches runtime state |

## 8. Wave and Score Tests

| ID | Test | Expected result |
|---|---|---|
| WAV-01 | Generate wave 1 | Only implemented, eligible enemies are selected within budget |
| WAV-02 | Generate wave with small remainder | Algorithm exits; it does not loop forever |
| WAV-03 | Reach waves 5 and 10 | Milestone flags and mixed/major formation logic activate |
| WAV-04 | Reach wave 20 | Transition hook/notice occurs and wave 21 can start |
| WAV-05 | Simulate high wave | Active count, spawn delay, and multipliers remain inside safe clamps |
| WAV-06 | Complete a wave | Wave number, score, and frontline distance increase once |
| WAV-07 | Restart after wave 5+ | Wave, timers, active spawns, score, multiplier, kills, and distance reset |
| SCR-01 | Defeat enemy | Score matches current formula and kill count increases once |
| SCR-02 | Fire hit/miss series | Accuracy is correct and division by zero is avoided |
| SCR-03 | Cross rating threshold | Defence Rating updates to the correct label |

## 9. Supply Tests

| ID | Test | Expected result |
|---|---|---|
| SUP-01 | Spawn blue crate | It appears in a readable drop zone and descends |
| SUP-02 | Shoot crate before ground | Exactly one valid reward applies |
| SUP-03 | Ignore crate | It expires without a reward |
| SUP-04 | Receive ammunition at full reserve | Use another valid reward or clamp; no overflow |
| SUP-05 | Reuse pooled crate | Reward flag, health, descent, and visuals reset |
| SUP-06 | Pause during drop | Descent and timeout follow the selected pause policy consistently |

## 10. Game Over and Restart Tests

| ID | Test | Expected result |
|---|---|---|
| GO-01 | Trigger game over | Final score, wave, kills, distance, time, and rating display |
| GO-02 | Press Fire on results | No weapon or enemy gameplay action occurs |
| GO-03 | Press Restart once | One clean reset begins |
| GO-04 | Press Restart repeatedly | No duplicate scene load, waves, managers, or pooled objects |
| GO-05 | Complete second run | Values belong only to the second run and game over still works |

## 11. Device Performance Test

Run a ten-minute development build on the Samsung Galaxy A26 5G.

Record:

- Average and worst frame time.
- CPU main-thread time.
- GPU time.
- Managed and total memory.
- Garbage collection spikes.
- Active enemy and pooled-object counts.
- Draw calls/batches and visible shadow casters.
- Battery/thermal warning or clear slowdown.

Pass target:

- Aim and fire remain responsive.
- The game targets 60 FPS and avoids repeated long stalls.
- No memory growth continues after pools reach their normal size.
- No audio clipping or uncontrolled voice count occurs.
- No crash, freeze, or stuck restart occurs.

If the target is missed, fix in this order: excessive spawns/logic, shadows and overdraw, repeated allocations, material/draw-call count, then decoration. Do not remove important HUD or hit readability first.

## 12. Submission Checks

- PDF filename is exactly `VGC202_A1_Alikhail_Mohammad.pdf`.
- Body text is 12-point and single-spaced.
- Cover identifies student, course, title, engine, and platform.
- All requested GDD topics, pseudocode, and flowcharts are present.
- Infinite-runner justification is explicit and does not describe a vehicle runner.
- Planned and implemented features are clearly separated.
- All recommended assets include source and licence notes.
- No third-party asset is included without a licence record.
- The Unity project opens using the recorded editor version.
- A backup of the project and a known-good APK exists before the demonstration.
