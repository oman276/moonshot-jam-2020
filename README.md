# moonshot-jam-2020
A game developed by me for the Game Off 2020 Jam (November 29, 2020)

~~~~

This game was developed on and off for about a month (November 1st to November 29th) for the Game Off 2020 Jam hosted by Github. I used C# and the Unity game engine 
to develop the game.

As opposed to my previous games, MOO-NSHOT was made during the school year, where I had other priorities beyond just making the game. In order to ensure I could complete the game 
and not fail any of my classes, I decided to drastically reduce the scope from my previous games. I also made a promise to complete a playable, completable build of the game 
before any art or sound effects were added, in order to ensure that the game was fun and fair as early as possible. As a result of this, MOO-NSHOT is (in my opinion) the most
polished and consistently fun game I've made so far. 

I was able to use all the techniques I've learned from the other games I've made, and I ran into very few serious coding challenges I wasn't capable of overcoming. This is partly
a result of the deliberately limited scope, and partly a result of everything I learned over my past projects. The biggest challenge I had was having the camera follow the player 
on the y-axis *without* following it on the x-axis or rotating with the ship. The solution I used was that the camera would check every frame for the y position of the ship and 
move towards it. I know it isn't a particularly efficient solution, but attaching the camera to the player would cause the camera to rotate with the player, and using triggers 
would cause an issue where the camera would seem "twitchy" as the player drifted in and out of the edge of the trigger. The "check every frame" solution didn't tank framerate as 
much as I was fearing, so it was an acceptable compromise.

So what did I learn from this project? I learned a lot of soft skills. I was very glad that I was finally able to resist the temptation to rapidly increase the scope of the 
project
