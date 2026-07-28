# Valley Sentinel - Asset Research

**Research date:** July 21, 2026  
**Status:** Recommendations only. Nothing has been downloaded, purchased, or imported.

Prices and store availability can change. Open the linked page and save a copy of the licence or invoice at the time of download. This table is project tracking, not legal advice.

## Recommended Visual Direction

Use one main stylized military set where possible, then fill gaps with CC0 assets that can be recoloured to the same tan, grey, olive, and blue palette. Avoid combining realistic PBR soldiers with very simple untextured scenery unless the materials are intentionally restyled.

For the MVP, the lowest-risk route is:

1. Prototype geometry made from Unity primitives.
2. [Military Assets (Mobile)](https://assetstore.unity.com/packages/3d/props/military-assets-mobile-314463) for a small free mobile-ready prop set, after checking its current package contents.
3. [Quaternius Ultimate Stylized Nature](https://quaternius.com/packs/ultimatestylizednature.html) or [Kenney Nature Kit](https://kenney.nl/assets/nature-kit) for consistent rocks and vegetation.
4. [Kenney Mobile Controls](https://kenney.nl/assets/mobile-controls) and [Kenney UI Audio](https://www.kenney.nl/assets/ui-audio) for interface placeholders.
5. One rigged humanoid with [Mixamo](https://helpx.adobe.com/creative-cloud/faq/mixamo-faq.html) animations only after a style and triangle-count test.

## Researched Assets and Sources

| Asset name/category | Source | Licence | Cost found | Style compatibility | Mobile suitability | Expected use | Attribution required? |
|---|---|---|---|---|---|---|---|
| Military Assets (Mobile) | [Unity Asset Store](https://assetstore.unity.com/packages/3d/props/military-assets-mobile-314463) | Standard Unity Asset Store EULA | Free | Strong candidate for stylized low-poly military props; inspect exact models before choosing | Listing says mobile optimized, uses a small asset set, and supports URP with minor material adjustment | MVP defensive props and possible vehicle/weapon placeholders | No public credit normally required by the standard EULA; keep licence record |
| Military Forest - Low Poly 3D Models Pack | [Unity Asset Store](https://assetstore.unity.com/packages/3d/environments/industrial/military-forest-low-poly-3d-models-pack-252966) | Standard Unity Asset Store EULA, Single Entity | USD 89 at research date | Very consistent complete-pack option with landscape, roads, mountains, buildings, vehicles, aircraft, sandbags, and props | Listing reports 428 low-poly assets, four materials/textures, and current Unity 6/URP compatibility; still profile selected assets | Paid one-pack route for most environment and vehicle categories | No public credit normally required; seat/entity rules apply |
| Low Poly Military Characters | [Unity Asset Store](https://assetstore.unity.com/packages/3d/characters/humanoids/low-poly-military-characters-197197) | Standard Unity Asset Store EULA | USD 15.99 at research date | Stylized low-poly soldiers; check colours against chosen environment | Listing describes mobile-friendly characters, roughly 1.5k-4.4k polygons, 512 textures, and humanoid rigs | Ground infantry variants | No public credit normally required; keep purchase record |
| Ultimate Stylized Nature Pack | [Quaternius](https://quaternius.com/packs/ultimatestylizednature.html) | CC0 | Free core download; optional paid source/engine tiers may exist | Strong fit for slightly cartoonish low-poly scenery | 60+ models; FBX/OBJ/glTF; low-poly and easy to atlas/recolour | Rocks, trees, grass, bushes, background nature | No, but credit is appreciated |
| Simple Nature Pack | [Quaternius](https://quaternius.com/packs/simplenature.html) | CC0 | Free | Very simple placeholder style | Only 13 models and low complexity | Early rock/tree blockout | No |
| Survival Pack | [Quaternius](https://quaternius.com/packs/survival.html) | CC0 | Free core download | Compatible with stylized props; test palette | 50+ FBX/OBJ/Blend props; suitable for selective mobile use | Crates, campsite/defence support props, tools | No |
| Zombie Apocalypse Kit | [Quaternius](https://quaternius.com/packs/zombieapocalypsekit.html) | CC0 | Free core download | Stylized kit may provide civilian/vehicle placeholders; not a final military identity | 60 models with characters, animations, environmental items, and vehicles; select only needed assets | Early vehicle or character experiments if style matches | No |
| Universal Base Characters | [Quaternius](https://quaternius.com/packs/universalbasecharacters.html) | CC0 | Free core download | Clean stylized base, but not military clothing | About 13k triangles per character is higher than desired for large enemy crowds; simplify or keep count low | Rig/animation tests or future customization experiments | No |
| Nature Kit | [Kenney](https://kenney.nl/assets/nature-kit) | CC0 | Free/donation | Clean, consistent low-poly shapes | 330 files; select a small subset and share materials | Rocks, vegetation, background scenery | No; Kenney credit optional |
| Survival Kit | [Kenney](https://kenney.nl/assets/survival-kit) | CC0 | Free/donation | Good with Kenney nature assets | 80 files with some animations; lightweight placeholder use | Crates, barriers, tools, campsite details | No; Kenney credit optional |
| Mobile Controls | [Kenney](https://kenney.nl/assets/mobile-controls) | CC0 | Free/donation | Neutral, readable UI set | 900 control/button files; import only required sprites and use sprite atlases | Aim joystick art, Fire/Reload/Pause button bases | No; Kenney credit optional |
| UI Audio | [Kenney](https://www.kenney.nl/assets/ui-audio) | CC0 | Free/donation | Neutral interface feedback | 50 short files; low runtime cost when compressed correctly | Button, pause, confirm, warning placeholder sounds | No; Kenney credit optional |
| Interface Sounds | [Kenney](https://kenney.nl/assets/interface-sounds) | CC0 | Free/donation | Alternative to UI Audio; do not import both full packs | 100 short files; import selected clips only | Reload-ready, score, crate, and menu feedback | No; Kenney credit optional |
| Mixamo humanoid animations | [Adobe Mixamo FAQ](https://helpx.adobe.com/creative-cloud/faq/mixamo-faq.html) | Adobe Mixamo terms; FAQ states royalty-free use in video games | Free with Adobe ID at research date | Animation source only; style depends on uploaded character | Suitable for one humanoid rig; reduce clips, compression, and bones if needed | Walk, rifle idle/attack, hit, and death prototypes | No normal in-game attribution stated; retain terms record |
| Poly Pizza individual low-poly models | [Poly Pizza](https://poly.pizza/) | Per-model CC0 or CC BY; verify each model page | Often free | Useful for single gap-filling objects but style varies by creator | Usually simple geometry; inspect texture/material count and scale | Parachute, crate, road sign, rock, simple weapon gaps | CC0: no. CC BY: yes, credit author, title, source, and licence |
| Sketchfab downloadable models | [Sketchfab licences](https://sketchfab.com/licenses) | Per-model Creative Commons or store licence | Free and paid | Wide style range; high inconsistency risk | Inspect triangles, textures, rigs, and licence before download | Only a missing specialist asset such as a parachute or drone | Depends on licence. Prefer CC0; CC BY requires credit. Reject Editorial and unclear assets |
| OpenGameArt assets | [OpenGameArt FAQ](https://opengameart.org/node/5571) | Per-asset: CC0, CC BY, CC BY-SA, OGA-BY, GPL, or other listed terms | Usually free | Mixed styles; use carefully | Varies widely; inspect each file and licence | Gun/explosion/warning audio or a specific VFX placeholder | Assume attribution unless the asset is clearly CC0 or author says otherwise |
| LowPoly Nature Pack by Quaternius | [OpenGameArt mirror](https://opengameart.org/content/lowpoly-nature-pack) | CC0 | Free | Same general Quaternius low-poly family | Small archive with FBX/OBJ/Blend | Backup source for rocks and vegetation | No |
| Unity default UI font / a verified OFL font | Unity project or a font distributor with an included OFL file | Unity licence or SIL Open Font License as packaged | Free | Choose a plain readable sans-serif | Use one or two weights and generate only required glyphs | HUD, results, and menus | Follow the included font licence; retain copyright notice if required |

## Category Coverage Plan

| Needed category | MVP source plan | Later source plan | Decision gate before import |
|---|---|---|---|
| Low-poly military characters/infantry | One test character from a verified paid/free listing or temporary capsule | Low Poly Military Characters or one matching themed pack | Humanoid rig, triangle count, textures, URP material, licence |
| Weapons/machine guns/turrets | Unity primitives for functional prototype; inspect Military Assets (Mobile) | Main themed pack or per-model CC0 asset | Separate yaw/pitch parts, scale, no real logos |
| Tanks/APCs/technical vehicles | None for MVP | Military Forest pack or individually verified low-poly pack | LOD, material count, collider plan, no full physics requirement |
| Helicopters/drones/jets | None for MVP | Main themed pack; specialist CC0 model only if style matches | Clear silhouette, simple rotor animation, low texture count |
| Mountain environment/rocks | Quaternius Ultimate Stylized Nature or Kenney Nature Kit | Main themed environment pack | Palette compatibility and mobile draw-call test |
| Roads/mountain paths | Simple Unity meshes | Main environment pack or authored spline mesh | One material and simple collider |
| Sandbags/defensive structures | Military Assets (Mobile) if contents fit; otherwise primitives | Military Forest or a matching pack | Scale, URP material, licence |
| Supply crates/parachutes | Simple authored crate and plane/parachute shape from primitives | Quaternius/Poly Pizza CC0 gap asset | Colour readability and per-model licence |
| Muzzle flashes/explosions/impacts | Simple Unity Particle System | Unity Asset Store free VFX with current URP/EULA check | Overdraw, pooled lifetime, no heavy shaders |
| UI icons/joystick/buttons | Kenney Mobile Controls | Same pack; avoid mixing icon families | Touch size and sprite-atlas import |
| Fonts | Unity-safe default or verified OFL sans-serif | Same family | Include licence text and test small-screen readability |
| Gun/explosion/helicopter audio | Temporary self-recorded/simple placeholder or verified CC0 individual clips | Verified OpenGameArt/Unity pack with source record | No NC licence, no unclear samples, reasonable file size |
| Wind/warning/shield sounds | Kenney UI/Interface for UI; verified CC0 ambience for wind | Custom mix from verified sources | Loop quality, licence, loudness, mobile compression |

## Licence Rules for This Project

1. Record the asset title, creator, exact URL, download date, licence, and local folder before import.
2. Prefer CC0 for individual web models and sounds.
3. For CC BY, add the required creator/title/source/licence entry to a project credits file and in-game Credits screen.
4. Do not use Non-Commercial, Editorial, No-Derivatives, or unclear licences.
5. Treat each Poly Pizza, Sketchfab, and OpenGameArt asset separately; the website name is not the licence.
6. Unity Asset Store assets must remain embedded in the game and not be redistributed as stand-alone source files. Observe Single Entity/seat rules.
7. Remove real-world logos, flags, insignia, and copied faction markings even if the model licence allows reuse.
8. Keep original licence files and invoices under a future `Documentation/Licences` folder, but do not import large legal/source archives into the runtime build.

## Current Recommendation

Do not buy a large pack before the input-and-wave prototype works. Use primitives and a small number of CC0 placeholders for the first phone build. If the project continues after the prototype, compare the USD 89 Military Forest one-pack option against the cheaper combination of Military Assets (Mobile), Low Poly Military Characters, and a CC0 nature pack. Choose the route that gives the most consistent style with the least material cleanup.
