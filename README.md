# Dead End


This is the final build of *Dead End*, a survival horror maze game developed as part of a course project.

### ⚠️ Important Notice
This release is for **educational and demonstration purposes only**.  
All third-party assets (music, character models, etc.) are used under licenses that prohibit commercial use or public distribution beyond academic settings.  
Please do not redistribute or reuse any of the included content outside of project or classroom contexts.


## How to Play
Download the repo as a zip file.  
Once extracted and your Unity environment is set up, open the project in Unity.  
Navigate to the `Scenes` folder and start the game by opening and running the `Main Menu` scene.


## Overview
**Dead End** is a time-based survival horror maze game where players must navigate through a dark and unsettling maze within a strict three-minute time limit. The goal is to find the exit before time runs out while avoiding a terrifying monster that awakens after one minute.

The monster starts slow, moving at half the player’s speed, but after two minutes, it enters Rage Mode, doubling its speed and tripling its attack damage. If the monster fails to catch the player by the end of three minutes, the game restarts.

Power-ups such as speed and health boosts are scattered throughout the maze, providing strategic opportunities to outmaneuver the creature. Every decision matters in this high-stakes, adrenaline-fueled escape.

---

## Gameplay

### Player Controls
- **WASD**: Move  
- **Shift**: Sprint  
- **E**: Grab power-ups  
- **Space**: Jump  

### Player Abilities
- Normal Speed: 5 units/sec  
- Sprint Speed: 7 units/sec (temporary boost, stamina constrained)  
- Speed Boost Power-Up: Increases speed by 2.5x for 10 seconds  
- Health Boost Power-Up: Restores +20 HP (only if current HP ≤ 80)  

### Player Animation States
- Idle (standing still)  
- Walking (normal speed)  
- Running (sprinting)  
- Flinch (hit reaction)  
- Collapse (death animation)  

---

## Enemy: The Monster

### Behavior & States
- **Idle (0-1 min)**: Spawns at maze start, remains still with idle animation.  
- **Hunting (1-2 min)**: Moves toward player at half player speed, uses pathfinding, attacks when in range (10 HP damage).  
- **Rage Mode (2-3 min)**: Speed doubles player speed, attack damage triples to 30 HP, aggressive chase animations.  
- **Self-Destruct (after 3 min)**: Monster explodes if player survives, player wins.

### Enemy Animations
- Idle: Slow breathing, minor head movements  
- Hunting: Slow, deliberate walking with heavy footsteps  
- Attack: Swinging or lunging motions  
- Rage Mode: Faster, erratic running with heavy breathing  

---

## Maze Layout & Game Mechanics
- Maze consists of interconnected corridors, dead ends, and multiple paths.  
- Power-ups spawn randomly every session to enhance replayability.  
- Monster always spawns at the maze start.  
- Exit location is fixed.  
- Timer displays remaining time before monster activation and game end.  
- Audio cues provide feedback on monster proximity.  

---

## Power-Ups
- **Health Boost**: +20 HP (max 100 HP)  
- **Speed Boost**: 2.5x speed increase for 10 seconds  

---

## Future Enhancements (Planned)
- **Stamina Drainage System**: Sprinting drains stamina; regeneration when not sprinting.  
- **HP-Based Speed Adjustments**:  
  - If HP ≤ 20: no sprinting allowed, speed boost limited to 1.25x  
  - If HP > 20: speed boost functions normally  
- **Maze Layout Variations**: Different maze designs for each session.  

---

## Licensing & Assets
- **Audio (Pixabay):**  
  - In-game music: Piano Horror Soundtrack  
  - Main menu music: Mystic Horror Thriller  
- **Character Models (Unity Asset Store):**  
  - Monster: Mutant Monster Asset  
  - Player: Spartan King OR Kyle Robot  

---

Feel free to explore, survive, and try to escape the **Dead End**!

---


### Contributors
- Kshrey Vishrant 
- Madhav Sondhi   

---

Thanks for playing!

"DeadEnd"  
