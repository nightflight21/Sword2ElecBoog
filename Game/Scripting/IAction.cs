using Sword.Casting;


namespace Sword.Scripting 
{
    /// <summary>
    /// A thing that is done in the game.
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        void Execute(Scene scene, Script script, IActionCallback callback);
    }
}