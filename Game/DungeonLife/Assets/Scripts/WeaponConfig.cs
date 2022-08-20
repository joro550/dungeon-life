using UnityEngine;

[CreateAssetMenu(menuName = "Weapon")]
public class WeaponConfig : ScriptableObject
{
    public float damage;
    public float speed;

    public void AddAttack(int value) 
        => speed += value;

    public void AddDamage(int value) 
        => damage += value;
}