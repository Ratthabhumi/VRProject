📝 Project Overview
Dino-M.A.R.S. is an immersive VR simulation designed to explore physics-based interaction in a virtual Mars research facility. Players can interact with environment objects (Baseball bats), engage with dynamic entities (Dinosaurs/T-Rex), and navigate through a modular sci-fi outpost using advanced VR locomotion techniques.

Key Features
Physics Interaction: Real-time collision detection and impulse calculation.

Dynamic Spawning: Automated C# Spawner system for batch object instantiation.

VR Locomotion: Teleportation Area and Anchor systems for seamless navigation.

Smart UI: World-space Billboard UI that always faces the player.

Optimized Performance: 72+ FPS stable on Meta Quest Pro using URP.

🛠️ Technical Stack
Engine: Unity 6 (6000.x)

Render Pipeline: Universal Render Pipeline (URP)

VR Framework: Unity XR Interaction Toolkit (XRI)

Target Hardware: Meta Quest Pro / Quest Series

Scripting Backend: IL2CPP (ARM64)

📂 Project Structure
/Assets/Models: Custom 3D models (Bat, Dinosaur, P'Tae).

/Assets/Scripts: C# scripts for Spawning, Scoring, and UI logic.

/Assets/Scenes: Main VR environments (Outpost on Desert).

/Assets/Settings: URP and XR Input configurations.

🚀 How to Run
Go to the Releases section.

Download the MarsDino_Mew.apk.

Sideload the APK to your Meta Quest Pro using SideQuest or Meta Quest Developer Hub.

Open the app from Unknown Sources in your headset.

⚙️ Development Highlights
1. URP Optimization
Converted legacy materials to URP to fix "Pink Texture" issues and utilized ASTC Texture Compression for mobile VR efficiency.

2. Interaction Logic
Implemented XR Grab Interactable for weapons and Ray Interactor for long-distance UI navigation. Used Teleportation Provider for comfort-focused movement.

3. Physics & Scoring
Collision-based events trigger real-time score updates displayed on a floating World-Space Canvas.

📜 Credits & Assets
Environment: Sci-Fi Styled Modular Pack

Logic/Code: Custom developed in C#

Font: Thaleah Pixel Font

-------------------------------------------------------

🎮 Game Flow: Dino-M.A.R.S. Experience
The gameplay is designed as a Loop-based Interaction system, following these sequential stages:

1. Start State (Initial Entry)
Initial Spawn: The player spawns inside a futuristic Mars Outpost research facility.

Interactive Menu: A large World-Space UI panel (featuring "P'Tae") is positioned in front of the player. It utilizes a Face-Camera (Billboard) script to ensure the menu always rotates to face the player's perspective.

Tutorial & Instructions: The screen displays basic gameplay mechanics and mission objectives.

Interaction: Players use the right controller's Ray Interactor (Laser Pointer) to select and trigger the "START" button to begin the simulation.

2. Gameplay & Interaction (In-Game Experience)
Weapon Acquisition: Upon starting, the system spawns a physics-based baseball bat on a pedestal. The player must reach out and grab it using the controller's Grip button via the XR Grab Interactable system.

Exploration: Navigation is handled through a Teleportation system. Players point their laser at the floor to instantly warp, allowing for rapid movement across the outpost while minimizing motion sickness.

Combat & Physics Engine: * The primary mission is to "smash" hordes of dinosaurs dynamically spawned throughout the facility.

Collision Impulse: When the bat impacts a dinosaur, the system calculates the Collision Impulse, causing the dinosaur to be knocked back realistically based on the physics vector of the swing.

Real-time Scoring: Every successful hit sends data to the Score Manager. A floating Scoreboard displays the current total, accompanied by a "+100" popup effect for immediate visual feedback.

3. Game Logic (Session Mechanics)
Timer System: Each session is time-limited (e.g., 60 seconds). A countdown timer is visible to the player to create a sense of urgency.

Dynamic Challenge: Players must strategically teleport to different locations to find and clear dinosaur clusters to achieve the highest possible score before time expires.

4. End State (Session Conclusion)
Game Over Panel: Once the timer hits zero, player controls are locked, and a Final Score Summary panel is displayed.

User Options:

RESTART: Resets the score and timer, instantly restarting the gameplay loop.

EXIT: Closes the application and returns the player to the Meta Quest Pro home environment.

----------------------------------------------------------------------------------------------
Technical Challenges & Solutions
Legacy Shader to URP Conversion: During asset integration, we encountered "Pink Texture" issues because the original Sci-Fi Modular Pack was built using legacy shaders. To resolve this, we utilized the Render Pipeline Converter in Unity to upgrade all materials to the Universal Render Pipeline (URP), ensuring compatibility and visual fidelity in VR.

Performance Optimization: Initially, the inclusion of high-density Unity Terrain led to excessively long build times (over 30 minutes) and potential frame rate instability. To address this, we removed the Terrain and replaced it with Modular Static Meshes. This optimization significantly reduced build times and maintained a constant 72+ FPS on the Meta Quest Pro.

Input & UI Interaction: We faced issues where the VR laser pointers would pass through the UI panels without triggering events. This was solved by implementing the Tracked Device Graphic Raycaster on the World-Space Canvas and configuring the XR Ray Interactor on the controllers.

Control Mapping (Meta Quest Pro)
Teleportation & Navigation: Use the Right Controller Thumbstick. Point the laser at the ground and release to instantly warp to the target location.

Object Interaction / Grab: Use the Side Grip Button. Reach out to the baseball bat and press the grip to hold the object.

Menu Selection: Use the Right Index Trigger. Aim the laser at the "START" or "EXIT" buttons and press the trigger to confirm the action.

Future Work & Scalability
Multiplayer Integration: Integrating networking frameworks like Photon Fusion or Unity Netcode to allow multiple users to interact and collaborate within the same Mars research facility.

Advanced AI Behavior: Enhancing the dinosaur entities with NavMesh AI to allow them to track and chase players, creating a more dynamic and challenging environment.

Enhanced Haptic Feedback: Fine-tuning the haptic impulses on the Meta Quest Pro controllers to vary in intensity based on the velocity of the baseball bat's swing during impact.
