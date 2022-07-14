using System.Collections.Generic;
using Sword.Casting;


namespace Sword.Scripting
{
    /// <summary>
    /// The current state of the game.
    /// </summary>
    /// <remarks>
    /// The responsibility of Scene is to provide access to the current state of the game.
    /// </remarks>
    public class Scene
    {
        private Cast _cast = new Cast();
        private Script _script = new Script();
        
        public Scene() { }

        public void AddAction(int phase, Action action)
        {
            string _phase;
            if (phase == 0)
                {_phase = Constants.INPUT;}
            else if (phase == 1)
                {_phase = Constants.UPDATE;}
            else
                {_phase = Constants.OUTPUT;}
            _script.AddAction(_phase, action);
        }

        public void AddActor(string group, Actor actor)
        {
            _cast.AddActor(group, actor);
        }

        public void ApplyChanges()
        {
            _cast.ApplyChanges();
            _script.ApplyChanges();
        }

        public void Clear()
        {
            _cast.Clear();
            _script.Clear();
        }

        public List<Action> GetAllActions(int phase)
        {
            return _script.GetAllActionsIn(phase);
        }

        public List<Actor> GetAllActors(string group)
        {
            return _cast.GetAllActors(group);
        }

        public List<T> GetAllActors<T>(string group)
        {
            return _cast.GetAllActors<T>(group);
        }

        public Actor GetFirstActor(string group)
        {
            return _cast.GetFirstActor(group);
        }

        public T GetFirstActor<T>(string group)
        {
            return _cast.GetFirstActor<T>(group);
        }

        public void RemoveAction(int phase, Action action)
        {
            _script.Remove(phase, action);
        }

        public void RemoveActor(string group, Actor actor)
        {
            _cast.Remove(group, actor);
        }
    }
}