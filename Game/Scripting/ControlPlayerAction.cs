using Sword.Casting;
using Sword.Services;


namespace Sword.Scripting
{
    public class ControlPlayerAction : Action
    {
        private KeyboardService keyboardService;

        public ControlPlayerAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, IActionCallback callback)
        {
            Player player = (Player)cast.GetFirstActor(Constants.PLAYER_GROUP);
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                player.SwingLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                player.SwingRight();
            }
            else
            {
                player.StopMoving();
            }
        }
    }
}