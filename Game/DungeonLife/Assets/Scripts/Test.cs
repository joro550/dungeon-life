using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] private Transform prefab;
    [SerializeField] private float strength = 1.3f;
    private Vector3 vector;

    public void OnMousePosition(InputValue inputValue)
    {
        vector = inputValue.Get<Vector2>();
        vector = Camera.main.ScreenToWorldPoint(vector);
    }

    private void OnAttack()
    {
        var prefabTransform = Instantiate(prefab, transform.position, Quaternion.identity);

        var shootingDirection = new Vector2(vector.x, vector.y);
        var shootingRotation = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        var prefabRigidBody = prefabTransform.GetComponent<Rigidbody2D>();
        prefabRigidBody.velocity = shootingDirection * strength;
        prefabTransform.transform.Rotate(new Vector3(0, 0, shootingRotation));

        Destroy(prefabTransform.gameObject, 1.0f);
    }
}