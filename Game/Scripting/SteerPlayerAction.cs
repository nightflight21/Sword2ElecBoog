using System;
using Sword.Casting;
using Sword.Scripting;
using Sword.Services;


namespace Sword.Scripting
{
    /// <summary>
    /// Steers the player left, right, up or down based on keyboard input.
    /// </summary>
    public class SteerPlayerAction : Sword.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        
        public SteerPlayerAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
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
                if (_keyboardService.IsKeyDown(KeyboardKey.W))
                {
                    directionY = -playerSpeed;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.S))
                {
                    directionY = playerSpeed;
                }

                // detect horizontal or x-axis direction
                if (_keyboardService.IsKeyDown(KeyboardKey.A))
                {
                    directionX = -playerSpeed;
                }
                else if (_keyboardService.IsKeyDown(KeyboardKey.D))
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