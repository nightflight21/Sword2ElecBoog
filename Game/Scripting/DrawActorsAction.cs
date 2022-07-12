//using System;
using Sword.Casting;
using Sword.Scripting;
using Sword.Services;


namespace Sword.Scripting
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        public DrawActorsAction(ServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // Get the actors from the cast.
                //Camera camera = scene.GetFirstActor<Camera>("camera");
                //Label instructions = scene.GetFirstActor<Label>("instructions");
                Actor player = scene.GetFirstActor("player");
                //Label status = scene.GetFirstActor<Label>("status");

                // Draw the actors on the screen. Note we have provided the camera as a second 
                // parameter when drawing the player. The videoservice uses the camera to translate
                // the player's position within the world to its position on the screen.
                _videoService.ClearBuffer();
                _videoService.DrawGrid(160, Color.Gray(), camera);
                _videoService.Draw(instructions);
                _videoService.Draw(player, camera);
                _videoService.Draw(status);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}