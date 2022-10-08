using System.Globalization;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float max;
    [SerializeField] private float current;
    [SerializeField] private UnityEvent OnDeathEvent;
    
    public void Awake() 
        => current = max;

    public void RemoveHealth(float damageDoneEvent)
    {
        current -= damageDoneEvent;

        if (current <= 0) OnDeath();
    }

    private void OnDeath()
    {
        OnDeathEvent?.Invoke();
        Destroy(gameObject);
    }

    public string GetValue() => current.ToString(CultureInfo.InvariantCulture);
}