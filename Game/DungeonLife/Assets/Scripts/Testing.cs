using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
    [SerializeField] private float strength = 0.2f;
    private Vector2 vector;

    public void OnMousePosition(InputValue inputValue) => vector = inputValue.Get<Vector2>();

    public void OnAttack()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;

        var shootingDirection = new Vector2(vector.x, vector.y);
        var shootingRotation = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        rb.velocity = shootingDirection * strength;
        transform.Rotate(0, 0, shootingRotation);
    }

    private float GetAngle(Vector2 mousePosition, Transform weapon)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var direction = (worldPosition - weapon.position).normalized;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}