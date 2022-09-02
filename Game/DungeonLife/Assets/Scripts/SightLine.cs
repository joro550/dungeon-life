using Event.UnityEvents;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SightLine : MonoBehaviour
{    
    [SerializeField]
    private Transform origin;

    [SerializeField] 
    private LayerMask layer;

    [SerializeField, Range(0, 100f)]
    private float radius = 1f;

    [SerializeField] 
    private UnityTransformEvent OnTriggerEnter;
    
    [SerializeField] 
    private UnityTransformEvent OnTriggerExit;
    
    private void Awake()
    {
        var collider2D = this.AddComponent<CircleCollider2D>();
        collider2D.radius = radius;
        collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var i = 1 << col.gameObject.layer;
        if ((layer & i) == 0) 
            return;
        
        OnTriggerEnter.Invoke(col.gameObject.transform);
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer != layer.value)
            return;
        
        OnTriggerExit.Invoke(null);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(origin.position, new Vector3(0, 0, 1), radius);
    }
#endif
}