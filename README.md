# Azra_Test_Proj README


Instructions:
1. Open Azra_Test_Proj in Unity 6.3 LTS

2. Open the main scene

3. Play Mode
- Press the Play Button in the Editor
- Use WASD/Arrow keys to move
- Collect all 10 triangle items to win
- Bounce pads will launch you away depending on your approach
- Avoid navy enemies, you lose after 5 collisions
- ESC opens & closes the pause menu

4. Player victory/defeat opens end menu where you can change the difficulty
- restarting preserves the chosen difficulty setting

5. To run the basic tests for adding score and subtracting health use the TestRunner tool in Windows->General->TestRunner and find the 3 BasicGameTests in EditMode.

Project Architecture:
Key Scripts:
- DifficultyController used to easily change the difficulty by affecting spawn rate, number of enemies, enemy speed, and invincibility duration. Used singletons to make it global.

- Bounceable was used as an abstract base class to allow both the player and hunter enemies to interact with the bounce pad. Both player and hunter inherit from this class. Used coroutines to make timed effects.

- ScoreManager/PlayerHealthManager used singletons to make it global. Used Unity Events to trigger UI updates and other interactions like invincibility.

- EndGameUI/PauseUI contains the restart logic that allows for easy scene resetting.

- GameManager used to check and edit win/lose conditions.

- PlayerMovement / PlayerInteractions had all of the controls and interactions with other objects. They were separated for cleaner architecture.

Trade Offs/Shortcuts:
- Bounce Pads: I used Vector2. Reflect to save time because it was easy to work with the rest of the physics based movement. However, it can sometimes feel slightly off. If given more time, I would have developed a more responsive and predictable mechanism with random placement on the map for the pads.

- Hunter Movement: I started out with transform movement because it allowed for the smoothest reactions, but this made them unable to react to the bounce pad, so I switched to physics based. The new issue I encountered was using addForce with FixedUpdate, which made the movement floaty and inaccurate, so I changed it to use Update. Ideally, I would explore a solution that allows for FixedUpdate physics based movement.

- Player Movement: Had a similar issue as the Hunter where movement in FixedUpdate felt too floaty and imprecise. Currently, there are still some issues with the precision of the precise movement, which I was unable to address due to time. Physics based movement was similarly chosen to make interactions with the bounce pad more seamless.

- Enemy Wall Behavior: Basic enemies still have a tendency to get stuck in the corners of the map because when they contact the map edges, they are assigned a random direction to travel away from the border. This was done to save time so that I wouldn’t have to track their transform and have them figure out a clean way away from the border.

- UI Panels: There was visual overlap between my pause and end game UI panels, and originally, I considered making a base class and making small changes to them. In the end, I kept them separate since it was simpler and more efficient, but it was less ideal from a modularization stand point.

- UI Slider: I wanted to include a segmented bar to make it clearer how much health there is, but ran out of time.