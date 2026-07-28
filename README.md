# Valley Sentinel

Valley Sentinel is the temporary working title for a low-poly, endless defence-runner made for VGP202 Mobile Game Development Assignment 1. The player stays at a fortified gun position on high ground and survives an unlimited sequence of procedural attacks. The battlefield, score, wave number, and frontline distance continue to advance until the player's health reaches zero.

## Project Information

| Item | Value |
|---|---|
| Unity version | Unity 6.3 LTS - 6000.3.9f1 |
| Render pipeline | Universal Render Pipeline 17.0.1 |
| Input | Unity New Input System 1.17.0 |
| Target platform | Android, landscape |
| Target device | Samsung Galaxy A26 5G |
| Target frame rate | 60 FPS |
| Company | Alikhail Games |
| Product | Valley Sentinel |
| Package ID | `com.alikhailgames.endlessdefender` |
| Current status | Project setup and design documentation only |

## Current Status

The project currently contains the official Unity cross-platform URP template, the planned project folder structure, an empty gameplay scene, project-specific input actions, Android-oriented player settings, and assignment documentation. Android is the active build target and Unity completed a clean batch import. There is no gameplay code yet. The scene is intentionally a clean camera-and-light starting point.

## Opening the Project

1. Open Unity Hub.
2. Select **Add > Add project from disk**.
3. Choose this project folder.
4. Open it with Unity **6000.3.9f1**.
5. Allow Unity to finish its first package import.
6. Open `Assets/_Project/Scenes/DefencePrototype.unity`.

Do not upgrade the editor version immediately before the class demonstration. A Unity version change can trigger a long reimport.

## Main Scene

`Assets/_Project/Scenes/DefencePrototype.unity` is the only enabled build scene. It currently contains only a camera and a directional light. Planned scenes are Bootstrap, MainMenu, DefencePrototype, and GameOver; the additional scenes will be added when their functions are needed.

## Planned Mobile Controls

- Right-side virtual joystick: horizontal turret rotation, vertical weapon pitch, and camera aim.
- Left-side Fire button: hold to fire the machine gun.
- Left-side Reload button: manual reload.
- Left-side Switch Weapon button: planned for later weapons.
- Left-side Special Weapon button: planned for later special abilities.
- Pause button: pause or resume the run.
- No movement joystick and no tap-to-target aiming.

Editor-only keyboard and mouse bindings are included in the input-actions asset for later testing. The actual on-screen controls will be connected during Phase 2.

## Folder Structure

```text
Assets/
  _Project/
    Art/{Characters,Enemies,Vehicles,Weapons,Environment,VFX,UI}
    Audio/{Music,SFX,Ambience}
    Materials/
    Prefabs/{Player,Weapons,Enemies,Vehicles,Environment,Pickups,UI}
    Scenes/
    Scripts/{Core,Input,Player,Weapons,Enemies,Waves,Pickups,UI,Data,Utilities}
    ScriptableObjects/{Weapons,Enemies,Waves,Upgrades}
    Settings/
    Documentation/
    Tests/
```

The original template folders remain under `Assets/` and have not been deleted.

## First Prototype Scope

The first playable build is limited to one valley environment, one stationary gun, one infantry enemy, endless waves, basic shield and health, score and HUD, one blue supply crate, game over, restart, and an Android build. Vehicles, aircraft, red crates, special weapons, progression, and multiple maps remain design-only future features.

## Documentation

- `GAME_DESIGN_DOCUMENT.md` - complete Assignment 1 design document.
- `ASSET_RESEARCH.md` - source, licence, cost, style, and mobile checks.
- `TECHNICAL_PLAN.md` - setup, architecture, input, performance, and implementation order.
- `CLASS_ARCHITECTURE.md` - class responsibilities and object relationships.
- `DEVELOPMENT_CHECKLIST.md` - twelve practical development phases.
- `TESTING_PLAN.md` - functional, device, performance, and submission checks.

## Important Build Notes

- Android is the active Unity build target. Android Build Support, SDK, NDK, and OpenJDK are installed with Unity 6000.3.9f1.
- ARM64 and IL2CPP are configured for the final Android build.
- No APK has been built yet. The first classroom phone connection still requires Android Developer Options, USB debugging, permission approval on the phone, and a blank Build and Run test.
- No third-party assets or packages have been downloaded or imported.
