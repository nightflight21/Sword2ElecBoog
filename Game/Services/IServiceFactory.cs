using Sword.Casting;

namespace Sword.Services
{
    public interface IServiceFactory
    {
        //IAudioService GetAudioService();
        KeyboardService GetKeyboardService();
        MouseService GetMouseService();
        //ISettingsService GetSettingsService();
        VideoService GetVideoService();
    }
}