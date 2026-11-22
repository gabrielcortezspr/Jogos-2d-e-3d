# Unity 2D Games

![Unity](https://img.shields.io/badge/Unity-2D-000000?logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-scripts-512BD4?logo=dotnet&logoColor=white)
![License](https://img.shields.io/badge/license-MIT-green)

Gameplay scripts (C#) from three 2D games I built in Unity. This was my first contact with
programming, so the code is kept as it was written at the time: informal names, comments in
Portuguese, no refactoring. It is here as a record of where I started.

| Game | Genre | What the scripts implement |
|---|---|---|
| [`morai`](scripts/morai) | Platformer | Player controller with run, crouch, variable-height jump and a "dead" form with its own movement; HUD and life timer; falling platforms, deadly walls, chasing and phantom enemies; menu and level transitions |
| [`robColor`](scripts/robColor) | Platformer | Robot with an energy bar, breakable bricks, projectiles, sensors, hazards, pause menu, start screen and level flow |
| [`tueTeste`](scripts/tueTeste) | Action platformer / shooter | Mouse aiming, dash with cooldown, mana and regeneration, critical hits and an ultimate attack, knockback, cannons and projectiles, enemy AI and scoring |

## Techniques used

- Physics with `Rigidbody2D`, collision and trigger callbacks (`OnCollisionEnter2D`,
  `OnTriggerEnter2D`, …).
- Input through `Input.GetAxis` / `GetButton` / `GetKey` and mouse position for aiming.
- Coroutines for delayed actions such as level transitions.
- Scene flow with `SceneManager` (menus, pause, next level, restart).
- UI with `UnityEngine.UI` and TextMeshPro; camera follow and color-shift effects.
- Audio through a small sound manager per game.

## Using the scripts

Only the scripts are versioned, not the full Unity projects (scenes, sprites and sounds were
left out). To try one, copy its folder into `Assets/` of a 2D project and attach the
components to the matching objects in the scene.

## License

[MIT](LICENSE)
