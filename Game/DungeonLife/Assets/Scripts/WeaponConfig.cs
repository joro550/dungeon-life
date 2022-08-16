using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class WeaponConfig : ScriptableObject
{
    public float damage;
    public float speed;

    public void AddAttack(float value) 
        => speed += value;

    public void AddDamage(float value) 
        => damage += value;
}