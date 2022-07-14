using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class DrawHudAction : Action
    {
        private IVideoService videoService;
        
        public DrawHudAction(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            Cast cast = scene._cast;
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);
            DrawLabel(cast, Constants.SCORE_GROUP, Constants.SCORE_FORMAT, stats.GetScore());
        }

        private void DrawLabel(Cast cast, string group, string format, int data)
        {
            string theValueToDisplay = string.Format(format, data);
            
            Label label = (Label)cast.GetFirstActor(group);
            Text text = label.GetText();
            text.SetValue(theValueToDisplay);
            Point position = label.GetPosition();
            videoService.DrawText(text, position);
        }
    }
}