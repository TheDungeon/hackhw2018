using System.Collections;
using System.Collections.Generic;

namespace HackHW2018.Collections
{
    /// <summary>
    /// This represents a collection of entities.
    /// Entities
    /// </summary>
    public class EntityList : IEnumerable<Entity>
    {
        private Scene scene;

        private Dictionary<string, Entity> _entities;
        private Dictionary<string, Entity> _adding;
        private HashSet<string> _removing;

        public EntityList()
        {
            _entities = new Dictionary<string, Entity>();
            _adding = new Dictionary<string, Entity>();
            _removing = new HashSet<string>();
        }

        public void AddEntity<T>(string tag, T entity)
            where T : Entity
        {
            _adding.Add(tag, entity);
        }

        public void AddEntity<T>(string tag)
            where T : Entity, new()
        {
            _adding.Add(tag, new T());
        }

        public void RemoveEntity<T>(string tag)
        {
            if (_adding.ContainsKey(tag))
            {
                _adding.Remove(tag);                
            }

            else if (_entities.ContainsKey(tag))
            {
                _removing.Add(tag);
            }
        }

        public void UpdateLists()
        {
            foreach (var ent in _adding)
            {
                _entities.Add(ent.Key, ent.Value);
            }
            _adding.Clear();

            foreach (var ent in _removing)
            {
                _entities.Remove(ent);
            }
            _removing.Clear();

            foreach (var ent in _entities)
            {
                ent.Value.Components.UpdateLists();
            }
        }

        public void Update()
        {
            foreach (var ent in _entities.Values)
            {
                if (ent.Updatable)
                    ent.Update();
            }
        }

        public void Render()
        {
            foreach (var ent in _entities.Values)
            {
                if (ent.Visible)
                    ent.Render();
            }
        }

        public Entity this[string id]
        {
            get => _entities[id];
            set => _entities[id] = value;
        }


        public IEnumerator<Entity> GetEnumerator()
        {
            return _entities.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
