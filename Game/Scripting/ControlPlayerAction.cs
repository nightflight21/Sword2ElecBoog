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

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            Racket racket = (Racket)cast.GetFirstActor(Constants.RACKET_GROUP);
            if (keyboardService.IsKeyDown(Constants.LEFT))
            {
                racket.SwingLeft();
            }
            else if (keyboardService.IsKeyDown(Constants.RIGHT))
            {
                racket.SwingRight();
            }
            else
            {
                racket.StopMoving();
            }
        }
    }
}