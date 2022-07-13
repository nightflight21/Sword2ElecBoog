using System;
using System.Collections.Generic;
using System.Numerics;              //necessary for Vector2
using Byui.Games.Casting;
using Byui.Games.Scripting;
using Byui.Games.Services;


namespace Example.Scrolling
{
    /// <summary>
    /// Moves the player within the game world while scrolling the screen.
    /// </summary>
    public class MovePlayerAction : Byui.Games.Scripting.Action
    {
        public MovePlayerAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors, including the camera, from the cast
                Camera camera = scene.GetFirstActor<Camera>("camera");
                Actor world = camera.GetWorld();
                Actor player = scene.GetFirstActor("player");
                Actor enemy = scene.GetFirstActor("enemy");
                
                // move the player and clamp it to the boundaries of the world.
                player.Move();
                //enemy.AntiMove();                                     //doesnt work
                Vector2 enemyposition1 = new Vector2(600, 500);        //creates a permanent position on the grid for the enemy
                enemy.MoveTo(enemyposition1 - camera.GetPosition());    //enemy's "movement" will be relative to the camera's position
                player.ClampTo(world);
                //enemy.ClampTo(world);                                 //probably not needed until the enemy gets random movements
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move player.", exception);
            }
        }
    }
}