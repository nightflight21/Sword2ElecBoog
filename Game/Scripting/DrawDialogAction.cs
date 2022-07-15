using System.Collections.Generic;
using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class DrawDialogAction : Action
    {
        private IVideoService videoService;
        
        public DrawDialogAction(IServiceFactory serviceFactory)
        {
            this.videoService = serviceFactory.GetVideoService();
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            List<Actor> actors = scene.GetAllActors(Constants.DIALOG_GROUP);
            foreach (Actor actor in actors)
            {
                Label label = (Label)actor;
                Text text = label.GetText();
                Point position = label.GetPosition();
                videoService.DrawText(text, position);
            }
        }
    }
}