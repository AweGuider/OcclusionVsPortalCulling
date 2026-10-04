# Occlusion vs Portal Culling

Unity test scenes for comparing two visibility-culling techniques, occlusion culling and portal culling: frame rate and render time across scene complexity and camera positions. Saxion *Advanced Tools* course, May–June 2024. The topic was not taken forward to the final assessment; the course was completed with [Utility vs Reflex AI](https://github.com/AweGuider/UtilityVsReflexBasedAI) instead.

## In the project

- **Two test environments**: a dense open scene full of varied objects, and a furnished cabin interior
- **Paired scenes**: an occlusion-culling version and a portal-culling version of each environment (`Occlusion Test 1/2`, `Portal Test 1/2`), with baked occlusion data
- **A culling toggle scene**: switches the camera between no culling and occlusion culling at runtime, so the same view can be measured both ways
- **A first-person spectator camera** for repeatable fly-throughs

<!-- TODO(owner): the culling toggle scene, ToggleCulling.cs, ToggleADoor.cs and the Test 1/2 scene folders are
     uncommitted in the local clone. Commit them with this README, or drop the toggle bullet. -->

Scenes: [`Assets/OcclusionVsPortalCulling/Level/Scenes`](OcclusionVsPortalCulling/Assets/OcclusionVsPortalCulling/Level/Scenes) · Unity 2022.3

`Unity` `C#` `Rendering` `Occlusion culling` `Portal culling`
