using System.Globalization;
using Event.Events;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float max;
    [SerializeField] private float current;
    [SerializeField] private UnityEvent OnDeathEvent;
    [SerializeField] private VoidEvent OnDeathVoidEvent;
    
    public void Awake() 
        => current = max;

    public void Hit(Transform transform)
    {
        if (!transform.TryGetComponent<Weapon2>(out var weapon))
            return;
        var damage = weapon.GetDamage();
        RemoveHealth(damage);
    }

    public void RemoveHealth(float damageDoneEvent)
    {
        current -= damageDoneEvent;

        if (current <= 0) OnDeath();
    }

    private void OnDeath()
    {
        OnDeathEvent?.Invoke();
        OnDeathVoidEvent?.Raise();
        Destroy(gameObject);
    }

    public string GetValue() => current.ToString(CultureInfo.InvariantCulture);
}