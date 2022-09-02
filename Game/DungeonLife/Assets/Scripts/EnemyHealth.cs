using System.Globalization;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float max;
    [SerializeField] private float current;

    public void Awake() 
        => current = max;

    public void RemoveHealth(WeaponConfig damageDoneEvent) 
        => current -= damageDoneEvent.damage;

    public string GetValue() => current.ToString(CultureInfo.InvariantCulture);
}