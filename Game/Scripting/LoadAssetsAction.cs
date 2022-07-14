using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class LoadAssetsAction : Action
    {
        //private AudioService audioService;
        private IVideoService videoService;
        
        public LoadAssetsAction(IVideoService videoService)//add AudioService audioService,
        {
            //this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            //audioService.LoadSounds("Assets/Sounds");
            videoService.LoadFonts("Assets/Fonts");
            videoService.LoadImages("Assets/Images");
        }
    }
}