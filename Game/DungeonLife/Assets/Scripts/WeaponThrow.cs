using UnityEngine;

public class WeaponThrow : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float throwSpeed;

    private Transform startingTransform;

    public float GetThrowSpeed() => throwSpeed;
    public float GetDamage() => damage;
}