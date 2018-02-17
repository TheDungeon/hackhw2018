using System;
using System.Collections.Generic;

namespace HackHW2018.Utils
{
    public class Emitter<T>
        where T : struct, IComparable, IFormattable
    {
        Dictionary<T, List<Action>> _eventQueue = new Dictionary<T, List<Action>>();
        
        public void AddListener(T eventType, Action handler)
        {
            List<Action> list = null;

            if (!_eventQueue.TryGetValue(eventType, out list))
            {
                list = new List<Action>();
                _eventQueue.Add(eventType, list);
            }

            list.Add(handler);
        }

        public void RemoveListener(T eventType, Action handler)
        {
            _eventQueue[eventType].Remove(handler);
        }

        public void Emit(T eventType)
        {
            List<Action> list = null;

            if (_eventQueue.TryGetValue(eventType, out list))
            {
                foreach (var action in list)
                {
                    action.Invoke();
                }
            }
        }
    }
}
