using UnityEngine;
using Event.Events;
using Event.UnityEvents;

public class CollisionWithLayer : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private UnityTransformEvent onCollision;
    [SerializeField] private TransformEvent onCollisionEntered;

    private void OnCollisionEnter2D(Collision2D col)
    {
        var isLayer = layer.value & 1 << col.gameObject.layer;
        if (isLayer != layer.value)
            return;

        onCollisionEntered?.Raise();
        onCollision.Invoke(col.transform);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var isLayer = layer.value & 1 << col.gameObject.layer;
        if (isLayer != layer.value)
            return;

        onCollisionEntered?.Raise();
        onCollision.Invoke(col.transform);
    }

    public void DestroyGameObject()
        => Destroy(gameObject);
}