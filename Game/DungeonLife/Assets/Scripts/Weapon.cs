using UnityEngine;
using Event.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform rotateAround;
    [SerializeField] private WeaponConfig weaponConfig;

    private Vector3 _rotation = Vector3.zero;
    private Vector3 _startingPosition = Vector3.zero; 

    public void Awake()
    {
        var position = transform.localPosition;
        _startingPosition = new Vector3(position.x, position.y, position.z);
    }

    public void ResetPosition()
    {
        transform.localPosition = _startingPosition;
        transform.localRotation = Quaternion.identity;
    }

    public void Rotate(int z) 
        => _rotation = new Vector3(0, 0, z);

    public void StopRotate() 
        => _rotation = Vector3.zero;

    public void AddAttackSpeed(int value)
        => weaponConfig.AddAttack(value);
    
    public void AddDamage(int value)
        => weaponConfig.AddDamage(value);
    
    public void FixedUpdate() 
        => transform.RotateAround(rotateAround.position, _rotation, Time.deltaTime * (weaponConfig.speed * 100));
}