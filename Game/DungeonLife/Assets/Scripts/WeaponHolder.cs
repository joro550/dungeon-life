using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform weaponPrefab;
    [SerializeField] private float throwTime = 1.3f;
    [SerializeField] private float throwSpeed = 3f;

    private Vector2 movement = Vector2.zero;

    // ReSharper disable once UnusedMember.Global
    public void OnMovement(InputValue inputValue) => movement = inputValue.Get<Vector2>();

    // ReSharper disable once UnusedMember.Global
    public void OnAttack()
    {
        var prefabTransform = Instantiate(weaponPrefab, transform.position, Quaternion.identity);

        var mousePosition = Mouse.current.position.ReadValue();
        var mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition).normalized;

        var position = new Vector2(mousePosition.x, mousePosition.y);
        var shootingRotation = Mathf.Atan2(mouseWorldPosition.y, mouseWorldPosition.x) * Mathf.Rad2Deg;
        
        var weapon = prefabTransform.GetComponentInChildren<WeaponThrow>();
        var prefabRigidBody = prefabTransform.GetComponentInChildren<Rigidbody2D>();

        prefabRigidBody.velocity = mouseWorldPosition * 1.5f;
        prefabTransform.transform.Rotate(new Vector3(0, 0, shootingRotation));
        Destroy(prefabTransform.gameObject, throwTime);
    }

    public bool HasWeapon() => GetComponentInChildren<WeaponThrow>() != null;
}