using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class InitializeDevicesAction : Action
    {
        //private IAudioService audioService;
        private IVideoService videoService;
        
        public InitializeDevicesAction(IVideoService videoService)//add IAudioService audioService,
        {
            //this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            //audioService.Initialize();
            videoService.Initialize();
        }
    }
}