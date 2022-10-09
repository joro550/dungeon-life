using UnityEngine;
using Event.Events;
using Event.UnityEvents;
using UnityEngine.Events;
using System.Globalization;

public class Health : MonoBehaviour
{
    [SerializeField] private float max;
    [SerializeField] private float current;
    
    [Header("Unity Events")]
    [SerializeField] private UnityEvent OnDeathEvent;
    [SerializeField] private UnityFloatEvent OnDamageTakenUnityEvent;
    
    [Header("Scriptable Events")]
    [SerializeField] private VoidEvent OnDeathVoidEvent;
    [SerializeField] private FloatEvent OnDamageTakenFloatEvent;
    
    public void Awake() 
        => current = max;

    public void Hit(Transform transform)
    {
        if (!transform.TryGetComponent<WeaponThrow>(out var weapon))
            return;
        var damage = weapon.GetDamage();
        RemoveHealth(damage);

        var healthNormalized = GetHealthNormalized();
        OnDamageTakenFloatEvent?.Raise(healthNormalized);
        OnDamageTakenUnityEvent?.Invoke(healthNormalized);
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
    private float GetHealthNormalized() => current / max;
}