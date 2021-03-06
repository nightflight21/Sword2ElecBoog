using System.Numerics;
using Sword.Casting;

namespace Sword.Services
{
    public class RaylibServiceFactory : IServiceFactory
    {
        //private static IAudioService AudioService;
        private static IKeyboardService KeyboardService;
        private static IMouseService MouseService;
        //private static ISettingsService SettingsService;
        private static IVideoService VideoService;
        private static IPhysicsService PhysicsService;

        public RaylibServiceFactory()
        {
            //SettingsService = new JsonSettingsService();
            //AudioService = new RaylibAudioService(SettingsService);
            KeyboardService = new RaylibKeyboardService();
            MouseService = new RaylibMouseService();
            VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);
            PhysicsService = new RaylibPhysicsService();
        }

        public RaylibServiceFactory(string filepath)
        {
            //SettingsService = new JsonSettingsService(filepath);
            //AudioService = new RaylibAudioService(SettingsService);
            KeyboardService = new RaylibKeyboardService();
            MouseService = new RaylibMouseService();
            VideoService = new RaylibVideoService(Constants.GAME_NAME,
            Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.BLACK);
        }

        //public IAudioService GetAudioService()
        //{
        //    return AudioService;
        //}

        public IKeyboardService GetKeyboardService()
        {
            return KeyboardService;
        }

        public IMouseService GetMouseService()
        {
            return MouseService;
        }

        //public ISettingsService GetSettingsService()
        //{
        //    return SettingsService;
        //}

        public IVideoService GetVideoService()
        {
            return VideoService;
        }

        public IPhysicsService GetPhysicsService()
        {
            return PhysicsService;
        }
    }
}