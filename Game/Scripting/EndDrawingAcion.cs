using Raylib_cs;
using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class EndDrawingAction : Action
    {
        private IVideoService videoService;
        
        public EndDrawingAction(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            videoService.FlushBuffer();
        }
    }
}