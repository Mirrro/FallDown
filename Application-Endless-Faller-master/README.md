# Test Project | Endless Faller 

*Test project for applicants*: Requires **Unity 2019.2.8f1**. 

![example](Images/example-faller.gif)

## Goal 

Implement a simple endless falling game where the character must fall between platforms to stay on screen. 

- Don't spend more than 6-8 hours for coding on it. 
- Concentrate on gameplay, data structures, architecture and separation of concerns. For the visual assets, unity default shapes can be used. If you desire, you can add custom assets, but the subject of evaluation will be the code and the implementation of the requested subjects. 
- Everything in the project is used for your reference, you can use any of the assets or completely remove all of them. 

## Mechanics 

### Player 

The player should be able to move left and right and fall when it doesn't have any platform below him. 

When the character is out of screen, either on the top or the bottom, the game ends. 

### Platforms 

The platforms should spawn from the bottom of the screen and go up. All of them must have a hole big enough for the character to fall. Once they exit the screen through the top, they should stop existing (either destroy, pool or deactivate them). 

## Requirements 

- On the main menu, I should see the current highscore and when pressing play, change to the game scene. 
- On the game scene, the game functionality should be similar to the one in the gif. 
- When the character is out of screen, either because he couldn't fall fast enough or he fell before the next platform was available, the player should lose. 
- Every time the character goes down a floor, his score should increase. 
- The platforms should be randomly generated. No two playthroughs should have the same pattern. 
- When losing, a menu showing me my last score, my current highscore and the buttons: "Restart" and "Go back to main menu" should appear. The buttons should take the user back to the home scene and restart the level. 
- When I press escape, the game should pause, and I should have a menu with the option "Continue" and "Go back to main menu". The buttons should either continue the game or take the user back to the home scene. 
- When surpassing my highscore, this should change in the UI. 
- The platform spawn rate and speed should increase the longer the game lasts. 
- When I surpass my highscore, this should persist,  and I should be able to see it in the UIs when I launch the game again. 
- As a product owner, I want to be able to change the initial spawn rate and speed of the platforms outside of Unity (json, xml, etc.). 
- Write [automated tests](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html). 

### Bonus points 

- The longer the game lasts, the faster the platforms should move (and the spawn rate should also become smaller) 
- Have some smooth transitions between level transitions (fading/effects/etc). 
- When surpassing my highscore, a new visual element should appear in the lost screen UI informing me of my achievement (like a text saying "You have a new highscore"). 
- When I'm about to surpass my highscore, a visual element should inform me of it (a different platform color, a particle effect, etc.). 
- Don't use PlayerPrefs for persistence. 
- Don't use OnBecameInvisible for destroying the player. 
- Add some details to make the game scene prettier (some lighting or particles should do the trick, be creative). 
- When restarting the game, don't reload the scene. 

## Implementation 

- Clone this repository. 
- Develop as you would do in a normal project. 
- Do not use copyright/third party libraries. 
- Upload this project to a repository in your account and invite [Bullrich](http://github.com/bullrich/) to it. 

## Delivery 

### Before implementation 

- Split the project in sub tasks and estimate the time it would take for each one. You should use [GitHub issues](https://help.github.com/en/github/managing-your-work-on-github/creating-an-issue) for this. A template has been provided. 
- Inform  <javier.bullrich@innerspace.eu> about the estimations. 
- Optionally, contact Javier Bullrich for requirements clarification. 

### Implementation 

- Functional build for x64 machines. 

### After implementation 

- Comment the execution time for each issue closed. You can also add some extra information explaining why a task took less or more time than the estimated.  [You can also link it to a commit using a keyword](https://help.github.com/en/enterprise/2.16/user/github/managing-your-work-on-github/closing-issues-using-keywords). 
- Review the project (what you learn, where you struggle, what you liked from what you did). You can use the *Review.md* for this. 
- Tag the final commit as "Release" and upload the build it to the GitHub releases page. 
- Inform Javier Bullrich of the finished projects. 

## Evaluation criteria 

- Project completion (game and tests) 
- Structure of the project and the code 
- How and which software patterns you use. 
- Maintainability and cleanliness of your code. 
- How you test your code. 
- Creativity 
- Development time (effectiveness) 

--- 

Questions at any time to <javier.bullrich@innerspace.eu>