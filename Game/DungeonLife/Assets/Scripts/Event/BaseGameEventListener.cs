using UnityEngine;
using UnityEngine.Events;

namespace Event
{
    public abstract class BaseGameEventListener<T, TE, TUer> : MonoBehaviour, IGameEventListener<T> 
        where TE : BaseGameEvent<T> where TUer : UnityEvent<T>
    {
        [SerializeField] private TE gameEvent;
        [SerializeField] private TUer response;

        public void OnEnable() 
            => gameEvent.RegisterListener(this);

        public void OnDisable() 
            => gameEvent.UnregisterListener(this);

        public void OnEventRaised(T value) => response.Invoke(value);
    }
}