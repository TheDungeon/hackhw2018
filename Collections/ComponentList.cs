using HackHW2018.Components;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HackHW2018.Collections
{
    public class ComponentList : IEnumerable<Component>
    {
        private List<Component> _components;
        private List<Component> _adding;
        private List<Component> _removing;

        public ComponentList()
        {
            _components = new List<Component>();
            _adding = new List<Component>();
            _removing = new List<Component>();
        }

        public void AddComponent<T>(T entity)
            where T : Component
        {
            _adding.Add(entity);
        }

        public void AddComponent<T>()
            where T : Component, new()
        {
            _adding.Add(new T());
        }

        public void RemoveComponent<T>()
            where T : Component
        {
            foreach (var a in _adding)
            {
                if (a is T)
                {
                    _adding.Remove(a);
                }
            }

           foreach (var a in _components)
            {
                if (a is T)
                {
                    _removing.Add(a);
                }
            }
        }

        public void UpdateLists()
        {
            foreach (var comp in _adding)
            {
                _components.Add(comp);
            }
            _adding.Clear();

            foreach (var comp in _removing)
            {
                _components.Remove(comp);
            }
            _removing.Clear();
        }

        public void Update()
        {
            foreach (var comp in _components)
            {
                comp.Update();
            }
        }

        public void Render()
        {
            foreach (var comp in _components)
            {
                comp.Render();
            }
        }

        public T FindComponent<T>()
            where T : Component
        {
            foreach (var comp in _components)
            {
                if (comp is T)
                {
                    return (T)comp;
                }
            }

            foreach (var comp in _adding)
            {
                if (comp is T)
                {
                    return (T)comp;
                }
            }

            return null;
        }

        public IEnumerable<T> FindComponents<T>()
            where T  : Component
        {
            foreach (var comp in _components)
            {
                if (comp is T)
                {
                    yield return (T)comp;
                }
            }

            foreach (var comp in _adding)
            {
                if (comp is T)
                {
                    yield return (T)comp;
                }
            }

            yield break;
        }

        public IEnumerator<Component> GetEnumerator()
        {
            return _components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
