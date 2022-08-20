using Event.Events;
using UnityEngine;
using UnityEngine.Events;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] private GameObject onCollisionWith;
    [SerializeField] private IntEvent onCollisionEntered;
    [SerializeField] private UnityEvent onCollision;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject != onCollisionWith)
            return;

        onCollisionEntered.Raise();
        onCollision.Invoke();
    }

    public void DestroyGameObject() 
        => Destroy(gameObject);
}