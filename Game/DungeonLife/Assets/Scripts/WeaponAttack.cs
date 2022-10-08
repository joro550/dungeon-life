using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform rotationPoint;

    private Vector2 mousePosition = Vector2.zero;
    private static readonly int Attack = Animator.StringToHash("Attack");

    public void OnMousePosition(InputValue inputValue)
    {
        mousePosition = inputValue.Get<Vector2>();
        
        var weapon2 = GetComponentInChildren<Weapon2>();
        if(weapon2  != null)
            weapon2.Rotate(GetAngle());
    }

    public void OnAttack()
    {
        var weapon2 = GetComponentInChildren<Weapon2>();
        if(weapon2  != null)
            weapon2.Attack(GetAngle());
    }

    private float GetAngle()
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var direction = (worldPosition - weapon.position).normalized;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return angle;
    }

    public Transform GetParent() => parent;
    public bool HasWeapon() => GetComponentInChildren<Weapon2>() != null;

    public void SetParent(Transform newWeapon)
    {
        // if (newWeapon.parent != null)
        //     return;
        // // //
        // weapon = newWeapon;
        // newWeapon.parent = parent;
    }
}