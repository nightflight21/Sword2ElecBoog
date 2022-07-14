using System;
using Sword.Casting;
using Sword.Scripting;
using Sword.Services;


namespace Sword.Scripting
{
    /// <summary>
    /// Steers the player left, right, up or down based on keyboard input.
    /// </summary>
    public class SteerPlayerAction : Action
    {
        private IKeyboardService keyboardService;
        
        public SteerPlayerAction(IServiceFactory serviceFactory)
        {
            this.keyboardService = serviceFactory.GetKeyboardService();
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        { 
            try
            {
                // declare basic speed and direction variables
                int playerSpeed = 5;
                int directionX = 0;
                int directionY = 0;

                // detect vertical or y-axis direction
                if (keyboardService.IsKeyDown(Constants.UP))
                {
                    directionY = -playerSpeed;
                }
                else if (keyboardService.IsKeyDown(Constants.DOWN))
                {
                    directionY = playerSpeed;
                }

                // detect horizontal or x-axis direction
                if (keyboardService.IsKeyDown(Constants.LEFT))
                {
                    directionX = -playerSpeed;
                }
                else if (keyboardService.IsKeyDown(Constants.RIGHT))
                {
                    directionX = playerSpeed;
                }

                // steer the player in the desired direction
                Actor player = scene.GetFirstActor("player");
                player.Steer(directionX, directionY);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't steer actor.", exception);
            }
        }
    }
}