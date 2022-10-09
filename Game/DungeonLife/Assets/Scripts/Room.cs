using System;
using Event.Events;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform playerStart;
    [SerializeField] private Transform cameraPosition;
    
    [Header("Starting Room")]
    [SerializeField] private bool isStartingRoom;
    [SerializeField] private VoidEvent OnStartingRoomLoaded;
    
    public void Activate(GameObject player)
    {
        gameObject.SetActive(true);
        player.transform.position = playerStart.position;
    }

    private void Start()
    {
        if (isStartingRoom)
            OnStartingRoomLoaded?.Raise();
    }

    public Transform GetCameraLocation() => cameraPosition;
}