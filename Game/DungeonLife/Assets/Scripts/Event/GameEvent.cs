using System.Collections.Generic;
using UnityEngine;

namespace Event
{
    [CreateAssetMenu(menuName = "events/game event")]
    public class GameEvent : ScriptableObject
    {
        private readonly List<GameEventListener> _listeners = new();

        public void Raise()
        {
            for (var i = _listeners.Count - 1; i >= 0; i--) 
                _listeners[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener) 
            => _listeners.Add(listener);

        public void UnregisterListener(GameEventListener listener) 
            => _listeners.Remove(listener);
    }
}