using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    [SerializeField] private float throwSpeed;
    [SerializeField] private float damage;
    
    private Transform startingTransform;
    private HingeJoint2D joint1;
    private Rigidbody2D rb1;

    private void Awake()
    {
        rb1 = GetComponent<Rigidbody2D>();
        joint1 = GetComponent<HingeJoint2D>();
    }

    public void Attack(Vector2 mousePosition)
    {
        transform.parent = null;
        joint1.connectedBody = null;
        
        var shootingDirection = new Vector2(mousePosition.x, mousePosition.y);
        var shootingRotation = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg;
        
        rb1.velocity = shootingDirection * throwSpeed;
        transform.Rotate(new Vector3(0, 0, shootingRotation));
    }

    public void Rotate(float getAngle)
        => transform.eulerAngles = new Vector3(0, 0, getAngle);

    public void SetParent(Transform parent)
    {
        if (!parent.TryGetComponent<WeaponHolder>(out var weaponHolder)) return;

        if (weaponHolder.HasWeapon())
            return;

        var parentRigidBody = parent.GetComponent<Rigidbody2D>();
        joint1.connectedBody = parentRigidBody;
        transform.parent = weaponHolder.GetParent();
    }

    public float GetThrowSpeed() => throwSpeed;
    public float GetDamage() => damage;
}