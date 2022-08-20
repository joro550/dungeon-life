using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    public abstract class BaseGameEvent<T> : ScriptableObject
    {
        private readonly List<IGameEventListener<T>> _listeners = new();

        public void Raise(T value)
        {
            for (var i = _listeners.Count - 1; i >= 0; i--) 
                _listeners[i].OnEventRaised(value);
        }

        public void RegisterListener(IGameEventListener<T> listener) 
            => _listeners.Add(listener);

        public void UnregisterListener(IGameEventListener<T> listener) 
            => _listeners.Remove(listener);
    }
}