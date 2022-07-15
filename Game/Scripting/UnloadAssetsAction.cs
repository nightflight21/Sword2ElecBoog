using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class UnloadAssetsAction : Action
    {
        private IAudioService audioService;
        private IVideoService videoService;
        
        public UnloadAssetsAction(IAudioService audioService, IVideoService videoService)
        {
            //this.audioService = audioService;
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, ActionCallback callback)
        {
            //audioService.UnloadSounds();
            videoService.UnloadFonts();
            videoService.UnloadImages();
        }
    }
}