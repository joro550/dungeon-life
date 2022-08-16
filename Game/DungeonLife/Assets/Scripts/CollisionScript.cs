using Event;
using UnityEngine;
using UnityEngine.Events;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] private GameObject onCollisionWith;
    [SerializeField] private GameEvent onCollisionEntered;
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