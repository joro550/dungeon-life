using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    private Transform startingTransform;
    private HingeJoint2D joint1;
    private Rigidbody2D rb1;

    private void Awake()
    {
        rb1 = GetComponent<Rigidbody2D>();
        joint1 = GetComponent<HingeJoint2D>();
    }

    private void Start()
    {
        // startingTransform.position = transform.position;
        // startingTransform.rotation = transform.rotation;
    }

    public void Attack(float angle)
    {
        transform.parent = null;
        var vector2 = new Vector2(2, 2) * angle;

        joint1.connectedBody = null;
        rb1.AddForce(vector2, ForceMode2D.Force);
    }

    public void Rotate(float getAngle)
        => transform.eulerAngles = new Vector3(0, 0, getAngle);

    public void SetParent(Transform parent)
    {
        if (!parent.TryGetComponent<WeaponAttack>(out var weaponHolder)) return;

        if (weaponHolder.HasWeapon())
            return;

        var parentRigidBody = parent.GetComponent<Rigidbody2D>();
        joint1.connectedBody = parentRigidBody;
        transform.parent = weaponHolder.GetParent();

        // transform.position = startingTransform.position;
        // transform.rotation = startingTransform.rotation;
    }
}