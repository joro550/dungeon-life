using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform weaponPrefab;
    [SerializeField] private float throwTime = 1.3f;
    [SerializeField] private float throwSpeed = 3f;

    private Vector2 movement = Vector2.zero;
    private bool canThrow = true;

    // ReSharper disable once UnusedMember.Global
    public void OnMovement(InputValue inputValue) => movement = inputValue.Get<Vector2>();

    // ReSharper disable once UnusedMember.Global
    public void OnAttack()
    {
        if(canThrow == false)
            return;

        canThrow = false;
        var ourPosition = transform.position;
        var prefabTransform = Instantiate(weaponPrefab, ourPosition, Quaternion.identity);

        var mousePosition = Mouse.current.position.ReadValue();
        var mouseWorldPosition = (Camera.main.ScreenToWorldPoint(mousePosition) - ourPosition).normalized;

        var weaponThrow = prefabTransform.GetComponent<WeaponThrow>();
        var prefabRigidBody = prefabTransform.GetComponent<Rigidbody2D>();
        var shootingRotation = Mathf.Atan2(mouseWorldPosition.y, mouseWorldPosition.x) * Mathf.Rad2Deg;

        prefabRigidBody.velocity = mouseWorldPosition * throwSpeed * weaponThrow.GetThrowSpeed();
        prefabTransform.transform.Rotate(new Vector3(0, 0, shootingRotation));
        Destroy(prefabTransform.gameObject, throwTime);
    }

    public bool HasWeapon() => GetComponentInChildren<WeaponThrow>() != null;
    public void CanThrow() => canThrow = true;
}