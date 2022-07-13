using System;
using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorsAction : Sword.Scripting.Action
    {
        private IVideoService videoService;

        public DrawActorsAction(IServiceFactory serviceFactory)
        {
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            try
            {
                // Get the actors from the cast.
                Camera camera = scene.GetFirstActor<Camera>("camera");
                //Label instructions = scene.GetFirstActor<Label>("instructions");
                Actor player = scene.GetFirstActor("player");
                //Label status = scene.GetFirstActor<Label>("status");
                Actor enemy = scene.GetFirstActor("enemy");

                // Draw the actors on the screen. Note we have provided the camera as a second 
                // parameter when drawing the player. The videoservice uses the camera to translate
                // the player's position within the world to its position on the screen.
                videoService.ClearBuffer();
                videoService.DrawGrid(160, Color.Gray(), camera);
                //videoService.Draw(instructions);
                videoService.Draw(player, camera);
                videoService.Draw(enemy);
                //videoService.Draw(status);
                videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }

    }
}