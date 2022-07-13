using System.Collections.Generic;
using Sword.Casting;

namespace Sword.Scripting
{
    /// <summary>
    /// A collection of actions.
    /// </summary>
    public class Script
    {
        private Dictionary<string, List<Action>> actions = new Dictionary<string, List<Action>>();
        private Dictionary<int, List<Action>> _current 
            = new Dictionary<int, List<Action>>();

        private Dictionary<int, List<Action>> _removed
            = new Dictionary<int, List<Action>>();
        /// <summary>
        /// Constructs a new instance of Script.
        /// </summary>
        public Script()
        {
        }

        /// <summary>
        /// Adds the given action to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="action">The action to add.</param>
        public void AddAction(string group, Action action)
        {
            if (!actions.ContainsKey(group))
            {
                actions[group] = new List<Action>();
            }

            if (!actions[group].Contains(action))
            {
                actions[group].Add(action);
            }
        }

        /// <summary>
        /// Clears the actions in the given group.
        /// </summary>
        /// <param name="group">The given group.</param>
        public void ClearActions(string group)
        {
            if (actions.ContainsKey(group))
            {
                actions[group] = new List<Action>();
            }
        }

        /// <summary>
        /// Clears all the actions in the script.
        /// </summary>
        public void ClearAllActions()
        {
            foreach(string group in actions.Keys)
            {
                actions[group] = new List<Action>();
            }
        }

        /// <summary>
        /// Gets the actions in the given group. Returns an empty list if there aren't any.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The list of actions.</returns>
        public List<Action> GetActions(string group)
        {
            List<Action> results = new List<Action>();
            if (actions.ContainsKey(group))
            {
                results.AddRange(actions[group]);
            }
            return results;
        }

        /// <summary>
        /// Removes the given action from the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="action">The action to remove.</param>
        public void RemoveAction(string group, Action action)
        {
            if (actions.ContainsKey(group))
            {
                actions[group].Remove(action);
            }
        }
        public void ApplyChanges()
        {
            foreach (int phase in _removed.Keys)
            {
                foreach(Action action in _removed[phase])
                {
                    if (_current[phase].Contains(action))
                    {
                        _current[phase].Remove(action);
                    }
                }
            }
            _removed.Clear();
        }
        public void Clear()
        {
            _current.Clear();
            _removed.Clear();
        }
        public List<Action> GetAllActionsIn(int phase)
        {
            Validator.CheckInRange(phase, Phase.Input, Phase.Output);
            List<Action> results = new List<Action>();
            if (_current.ContainsKey(phase))
            {
                results = _current[phase];
            }
            return results;
        }  
        public void Remove(int phase, Action action)
        {
            Validator.CheckInRange(phase, Phase.Input, Phase.Output);
            Validator.CheckNotNull(action);
            
            if (!_removed[phase].Contains(action))
            {
                _removed[phase].Add(action);
            }
        }              
    }
}