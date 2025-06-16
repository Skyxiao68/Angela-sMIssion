Game Design Report Assignment 4
Group 4
Ben Lai 2656867
Uwais Noor Moosa 2912066


What changed from the previous version.
• We fixed the transform issue that caused sprites to swing on a pivot affecting aim
• Added 4 more enemy types.
• Enemy Ai is now polished they have a vision cone, switch states reliably and are
using Raycasting for detection, this means that they stop detecting players
through walls, they can dynamically move and navigate around furniture and
most importantly they have stopped shooting through walls
• Added a shader and lights to allow the player to detect enemies within the Fog of
war, they still cannot see the enemy but now enemies will not sneak up on the
player because this gives the player a general direction at which the enemy is at
• The shader outline indicates what state the enemy is in.
• Added shaders to almost everything to stylize the game
• Fixed the particles systems and improved their looks
• Added sounds: Detection sound, player grunt, enemy death grunt, player health
threshold sounds, enemy shoot, boss shoot and boss destruction, level 2,3 and
boss level background music.
• Added 3 more levels
• Added the story that has been originally planned for the game.
• Balance changes: Player damage, enemy health, enemy damage, boss health
and damage.
• Added health bar and cleaned up UI.
• Interactable elements are now interactable, instead of the player going near to
the object to automatically pick it up with a collider.
• Polished Game feel elements, Camera Shake, Fog of war lighting and shooting.
Reflection


REFLECTION

This version of the project is planned to be the final iteration for the course, we focused
on polishing the mechanics first (Fixing the movement, the particles and sounds for
shooting and the fog of war mechanic) and proceeded to stylize the game by adding
shaders to everything that made the game look better , lighting to support the fog of war
(in the previous version the light was normal whilst only a sprite mask acted as the fog
of war itself, now these elements work together to get the final version of the fog which
gave it the intended look we were going for.), the story is now the final version of what we
wrote and is no longer being a placeholder (it may be rough for my standards but our
game is a top down shooter that is focusing on mechanics and game feel rather than
story but we wanted to tell a story that is similar to a game we like in our group called
Ready or Not), the atmosphere of the game is now what we intended with the aesthetics
we included.
We added everything that we wanted to add from our game design document and even
more such as the boss fight level which shifts the dynamic of the core gameplay to
justify it being a boss fight, we barely changed anything in the document.
The only thing we actually removed was our inventory system because it did not relate
to the game at all, but we got a better system. It conveys our story in a more engaging
way.
Overall we accomplished what we set out to do with the game and have succeeded in
accomplishing our scope.