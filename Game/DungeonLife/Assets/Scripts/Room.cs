using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform playerStart;
    [SerializeField] private Transform cameraPosition;

    public void Activate(GameObject player)
    {
        player.transform.position = playerStart.position;
        var transformPosition = Camera.main.transform.position;
        Camera.main.transform.position =
            new Vector3(transformPosition.x, cameraPosition.position.y, transformPosition.z);

    }
}