using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody2D;

    public void Awake() 
        => _rigidbody2D = GetComponent<Rigidbody2D>();

    public void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, vertical, 0);
        _rigidbody2D.MovePosition(transform.position + movement * speed * Time.deltaTime);
    }
}