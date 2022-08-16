using System;
using Event;
using UnityEngine;
using UnityEngine.Events;

public class CollisionWithTag : MonoBehaviour
{
    [SerializeField] private string onCollisionWith;
    [SerializeField] private UnityEvent onCollision;
    [SerializeField] private GameEvent onCollisionEntered;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(onCollisionWith))
            return;

        onCollisionEntered?.Raise();
        onCollision.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(onCollisionWith))
            return;

        onCollisionEntered?.Raise();
        onCollision.Invoke();
    }

    public void DestroyGameObject()
        => Destroy(gameObject);
}