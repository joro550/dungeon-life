using UnityEngine;

public class CrossHair : MonoBehaviour
{
    public void Move(Vector3 screenToWorldPoint)
    {
        transform.position = new Vector3(screenToWorldPoint.x, screenToWorldPoint.y, 0);
    }
}