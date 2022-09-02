using Event.UnityEvents;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] 
    private UnityFloatEvent TakeDamageEvent;
    
    public void TakeDamage(float damage) 
        => TakeDamageEvent.Invoke(damage);
}