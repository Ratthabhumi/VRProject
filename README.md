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
