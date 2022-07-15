using System.Collections.Generic;
using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class DrawEnemyAction : Action
    {
        private IVideoService videoService;
        
        public DrawEnemyAction(IServiceFactory serviceFactory)
        {
            this.videoService = serviceFactory.GetVideoService();
        }

        public void Execute(Scene scene, Script script, IActionCallback callback)
        {
            Cast cast = scene._cast;

            List<Actor> enemies = cast.GetActors(Constants.ENEMY_GROUP);
            foreach (Actor actor in enemies)
            {
                Enemy enemy = (Enemy)actor;
                Body body = enemy.GetBody();

                Rectangle rectangle = body.GetRectangle();
                Point size = rectangle.GetSize();
                Point pos = rectangle.GetPosition();
                videoService.DrawRectangle(size, pos, Constants.PURPLE, false);

                //Animation animation = enemy.GetAnimation();
                //Image image = animation.NextImage();
                Point position = body.GetPosition();
                //videoService.DrawImage(image, position);
            }
        }
    }
}