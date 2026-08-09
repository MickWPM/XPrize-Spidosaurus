# Spidosaurus Animation

This repo contains the project files for the development of a procedurally animated VR controlled spider like creature. 
The main driver for the components as developed is a smooth VR user experience, ensuring movement is responsive and at no stage is camera movement control taken from the player. The limb movement must be natrual and avoid limb/limb or limb/terrain clipping.

<img width="848" height="478" alt="VR-spider" src="https://github.com/user-attachments/assets/3787ae8a-9693-4b89-9587-234289db079b" />

The scope of the current implementation is:
- Head movement purely driven by VR input; full camera control retained by user.
- Foot target position tied to head position through maintainance of local offsets and grounded by raycasts.
- Designer friendly gizmos to aid foot setup including movement threshold per foot.
- Dynamic foot movement based on threshold distance to foot target position and deconflicted with opposing legs to ensure stability.
- Body target position calculated based on mean location of all feet.

[Video of component in action including both editor and VR view](https://youtube.com/shorts/rEN90z4NAwc)
