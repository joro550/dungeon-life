using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform weaponPrefab;
    private Vector2 mousePosition = Vector2.zero;

    public void OnMousePosition(InputValue inputValue)
    {
        mousePosition = inputValue.Get<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        // var weapon2 = GetComponentInChildren<Weapon2>();
        // if(weapon2 != null)
        //     weapon2.Rotate(GetAngle());
    }

    public void OnAttack()
    {
        // var weapon2 = GetComponentInChildren<Weapon2>();
        // if(weapon2  != null)
        //     weapon2.Attack(mousePosition);
        
        var prefabTransform = Instantiate(weaponPrefab, transform.position, Quaternion.identity);
        var shootingDirection = new Vector2(mousePosition.x, mousePosition.y);
        var shootingRotation = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        
        var weapon = prefabTransform.GetComponentInChildren<Weapon2>();
        var prefabRigidBody = prefabTransform.GetComponentInChildren<Rigidbody2D>();

        prefabRigidBody.velocity = shootingDirection * weapon.GetThrowSpeed();
        prefabTransform.transform.Rotate(new Vector3(0, 0, shootingRotation));
        Destroy(prefabTransform.gameObject, 1.3f);
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
}