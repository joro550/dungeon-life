using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform playerStart;
    [SerializeField] private Transform cameraPosition;

    public void Activate(GameObject player)
    {
        gameObject.SetActive(true);
        player.transform.position = playerStart.position;
    }

    public Transform GetCameraLocation() => cameraPosition;
}