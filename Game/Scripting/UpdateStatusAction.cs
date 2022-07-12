using System;
using System.Collections.Generic;
using Sword.Casting;
using Sword.Scripting;
using Sword.Services;


namespace Example.Scrolling
{
    /// <summary>
    /// Updates the status information at the top of the screen.
    /// </summary>
    public class UpdateStatusAction : Sword.Scripting.Action
    {
        public UpdateStatusAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the player and status actors from the cast
                Actor player = scene.GetFirstActor("player");
                Label status = scene.GetFirstActor<Label>("status");

                // update the status actor with the player info
                string newInfo = $"x:{player.GetPosition().X}, y:{player.GetPosition().Y}";
                status.Display(newInfo);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't update status.", exception);
            }
        }
    }
}