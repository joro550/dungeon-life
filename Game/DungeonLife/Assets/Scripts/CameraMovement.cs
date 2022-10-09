using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraFollowTransform;
    
    public void Move(Transform toPosition)
    {
        var moveToPosition = new Vector3(toPosition.position.x, toPosition.position.y, 0);
        cameraFollowTransform.transform.position = moveToPosition;
    }
}