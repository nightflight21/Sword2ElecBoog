using System.Collections.Generic;
using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class DrawEnemyAction : Action
    {
        private IVideoService videoService;
        
        public DrawEnemyAction(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Scene scene, Script script, ActionCallback callback)
        {
            Cast cast = scene._cast;

            List<Actor> enemies = cast.GetActors(Constants.Enemy_GROUP);
            foreach (Actor actor in enemies)
            {
                Brick brick = (Brick)actor;
                Body body = brick.GetBody();

                if (brick.IsDebug())
                {
                    Rectangle rectangle = body.GetRectangle();
                    Point size = rectangle.GetSize();
                    Point pos = rectangle.GetPosition();
                    videoService.DrawRectangle(size, pos, Constants.PURPLE, false);
                }

                Animation animation = brick.GetAnimation();
                Image image = animation.NextImage();
                Point position = body.GetPosition();
                videoService.DrawImage(image, position);
            }
        }
    }
}