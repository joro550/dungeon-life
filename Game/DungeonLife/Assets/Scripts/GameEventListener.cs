using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent gameEvent;
    [SerializeField] private UnityEvent response;

    public void OnEnable() 
        => gameEvent.RegisterListener(this);

    public void OnDisable() 
        => gameEvent.UnregisterListener(this);

    public void OnEventRaised() 
        => response.Invoke();
}