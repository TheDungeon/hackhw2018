using System.Collections;
using System.Collections.Generic;

namespace HackHW2018.Collections
{
    /// <summary>
    /// This represents a collection of entities.
    /// Entities are refered to 
    /// </summary>
    public class EntityList : IEnumerable, IEnumerable<Entity>
    {
        private List<Entity> _entities;
        private HashSet<Entity> _adding;
        private HashSet<Entity> _removing;

        public EntityList()
        {
            _entities = new List<Entity>();
            //_hash
        }

        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
