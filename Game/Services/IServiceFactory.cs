using Sword.Casting;

namespace Sword.Services
{
    public interface IServiceFactory
    {
        //IAudioService GetAudioService();
        IKeyboardService GetKeyboardService();
        IMouseService GetMouseService();
        //ISettingsService GetSettingsService();
        IVideoService GetVideoService();
        IPhysicsService GetPhysicsService();
    }
}