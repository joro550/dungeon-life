using System.Globalization;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float max;
    [SerializeField] private float current;

    public void Awake() 
        => current = max;

    public void RemoveHealth(float damageDoneEvent)
    {
        current -= damageDoneEvent;

        if (current <= 0) OnDeath();
    }

    private void OnDeath() 
        => Destroy(gameObject);

    public string GetValue() => current.ToString(CultureInfo.InvariantCulture);
}