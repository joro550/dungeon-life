using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
    public void OnMousePosition(InputValue inputValue)
    {
        var vector = inputValue.Get<Vector2>();

        var transformEulerAngles = GetAngle(vector, transform);
        transform.eulerAngles = new Vector3(0, 0, transformEulerAngles);
    }
    
    private float GetAngle(Vector2 mousePosition, Transform weapon)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        var direction = (worldPosition - weapon.position).normalized;
        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}