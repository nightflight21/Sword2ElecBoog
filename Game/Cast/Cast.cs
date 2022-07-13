using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Sword.Casting
{
    /// <summary>
    /// A collection of actors.
    /// </summary>
    public class Cast
    {
        private Dictionary<string, List<Actor>> actors = new Dictionary<string, List<Actor>>();

        private Dictionary<string, List<Actor>> _current 
            = new Dictionary<string, List<Actor>>();
            
        private Dictionary<string, List<Actor>> _removed 
            = new Dictionary<string, List<Actor>>();

        /// <summary>
        /// Constructs a new instance of Cast.
        /// </summary>
        public Cast()
        {
        }

        /// <summary>
        /// Adds the given actor to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to add.</param>
        public void AddActor(string group, Actor actor)
        {
            if (!actors.ContainsKey(group))
            {
                actors[group] = new List<Actor>();
            }

            if (!actors[group].Contains(actor))
            {
                actors[group].Add(actor);
            }
        }

        /// <summary>
        /// Clears the actors in the given group.
        /// </summary>
        /// <param name="group">The given group.</param>
        public void ClearActors(string group)
        {
            if (actors.ContainsKey(group))
            {
                actors[group] = new List<Actor>();
            }
        }

        /// <summary>
        /// Clears all the actors in the cast.
        /// </summary>
        public void ClearAllActors()
        {
            foreach(string group in actors.Keys)
            {
                actors[group] = new List<Actor>();
            }
        }

        /// <summary>
        /// Gets the actors in the given group. Returns an empty list if there aren't any.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The list of actors.</returns>
        public List<Actor> GetActors(string group)
        {
            List<Actor> results = new List<Actor>();
            if (actors.ContainsKey(group))
            {
                results.AddRange(actors[group]);
            }
            return results;
        }

        /// <summary>
        /// Gets all the actors in the cast.
        /// </summary>
        /// <returns>A list of all actors.</returns>
        public List<Actor> GetAllActors()
        {
            List<Actor> results = new List<Actor>();
            foreach (List<Actor> result in actors.Values)
            {
                results.AddRange(result);
            }
            return results;
        }

        /// <summary>
        /// Gets the first actor in the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The first actor.</returns>
        public Actor GetFirstActor(string group)
        {
            Actor result = null;
            if (actors.ContainsKey(group))
            {
                if (actors[group].Count > 0)
                {
                    result = actors[group][0];
                }
            }
            return result;
        }

        /// <summary>
        /// Removes the given actor from the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="actor">The actor to remove.</param>
        public void RemoveActor(string group, Actor actor)
        {
            if (actors.ContainsKey(group))
            {
                actors[group].Remove(actor);
            }
        }
        public void ApplyChanges()
        {
            foreach (string group in _removed.Keys)
            {
                foreach(Actor actor in _removed[group])
                {
                    if (_current[group].Contains(actor))
                    {
                        _current[group].Remove(actor);
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
        public List<Actor> GetAllActors(string group)
        {
            Validator.CheckNotBlank(group);
            List<Actor> results = new List<Actor>();
            if (_current.ContainsKey(group))
            {
                results = _current[group];
            }
            return results;
        }
        public List<T> GetAllActors<T>(string group)
        {
            Validator.CheckNotBlank(group);
            List<T> results = new List<T>();
            if (_current.ContainsKey(group))
            {
                foreach(object actor in _current[group])
                {
                    results.Add((T)actor);
                }
            }
            return results;
        }
        public T GetFirstActor<T>(string group)
        {
            Validator.CheckNotBlank(group);
            T result = default(T);
            List<T> actors = GetAllActors<T>(group);
            if (actors.Count > 0)
            {
                result = actors[0];
            }
            return result;
        }    
        public void Remove(string group, Actor actor)
        {
            Validator.CheckNotBlank(group);
            Validator.CheckNotNull(actor);
            
            if (!_removed[group].Contains(actor))
            {
                _removed[group].Add(actor);
            }
        }
                                    
    }
}