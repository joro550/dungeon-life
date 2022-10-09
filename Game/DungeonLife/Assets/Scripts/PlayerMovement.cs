using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform body;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Rigidbody2D _rigidbody2D;
    private Vector2 input = Vector2.zero;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    public void Awake()
        => _rigidbody2D = GetComponent<Rigidbody2D>();

    // ReSharper disable once UnusedMember.Global
    public void OnMovement(InputValue inputValue) => input = inputValue.Get<Vector2>();

    public void FixedUpdate()
    {
        var targetSpeed = new Vector3(input.x, input.y, 0).normalized;
        if (targetSpeed.x != 0 || targetSpeed.y != 0)
        {
            animator.SetBool(IsWalking, true);
        }
        else
        {
            animator.SetBool(IsWalking, false);
        }

        // if (targetSpeed.x < 0)
        // {
        //     body.Rotate(new Vector3(0, 0, 0), 180);
        // }

        spriteRenderer.flipX = targetSpeed.x switch
        {
            < 0 => true,
            > 0 => false,
            _ => spriteRenderer.flipX
        };

        var deltaSpeed = targetSpeed * speed * Time.deltaTime;
        if(deltaSpeed != Vector3.zero)
            _rigidbody2D.MovePosition(transform.position + deltaSpeed);
    }
}