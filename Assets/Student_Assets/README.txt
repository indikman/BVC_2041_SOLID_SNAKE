As I was playtesting, I realized issues I just couldn't find an answer to.
With the doors, I realized that the door meshes on some doors would become combined in playmode for some odd reason.
This would lead these doors to just not be able to move at all.
For doors that have mesh colliders, the colliders do move and can let the player pass through. But in game, the actual door mesh doesn't move
You can try to re-assign their meshes in playmode, but they don't save once you exit out of playmode.
The front door to the shop, for example, doesn't have its mesh combined when the game is in play mode. This means it can easily be movable.
I have no idea why this is, but I know my code works. The meshes for some doors just get combined to "root scene" and I don't even know what that means.

For Details on Task Two:
The back door behind the shop, the front door, and the countertop door that blocks off the store to the backroom are the doors I've attached scripts to.
I chose only three doors because they already had mesh colliders and adding mesh colliders to doors that originally didn't have them, they become really janky.
The back door would close on event, the front door would open on event, and the countertop door would open on event.
The countertop door is hard to see in playing mode because like I said, the mesh is combined, but in scene mode, you can clearly see the mesh collider moving.
This can allow the player to pass through.