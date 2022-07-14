using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class StartDrawingAction : Action
    {
        private IVideoService videoService;
        
        public StartDrawingAction(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            videoService.ClearBuffer();
        }
    }
}