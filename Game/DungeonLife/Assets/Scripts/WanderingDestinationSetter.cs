using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class WanderingDestinationSetter : MonoBehaviour
{
    public float radius = 20;

    private IAstarAI ai;

    private void Start () {
        ai = GetComponent<IAstarAI>();
    }

    private Vector3 PickRandomPoint () {
        var point = Random.insideUnitCircle * radius;

        point.y = 0;
        var aiPosition = ai.position;
        point += new Vector2(aiPosition.x, aiPosition.y);
        return point;
    }

    private void Update ()
    {
        // Update the destination of the AI if
        // the AI is not already calculating a path and
        // the ai has reached the end of the path or it has no path at all
        if (ai.pathPending || (!ai.reachedEndOfPath && ai.hasPath)) 
            return;
        
        ai.destination = PickRandomPoint();
        ai.SearchPath();
    }
}
