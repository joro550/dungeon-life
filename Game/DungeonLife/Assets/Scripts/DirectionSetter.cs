using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(AIDestinationSetter))]
public class DirectionSetter : MonoBehaviour
{
    private AIDestinationSetter destinationSetter;

    private void Awake() 
        => destinationSetter = GetComponent<AIDestinationSetter>();

    public void SetDestination(Transform targetTransform) 
        => destinationSetter.target = targetTransform;
}