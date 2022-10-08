using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Room room;
    
    private bool isOpen;
    private static readonly int Open = Animator.StringToHash("Open");

    public void OpenDoor()
    {
        animator.SetTrigger(Open);
        isOpen = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isOpen || !col.TryGetComponent<PlayerMovement>(out _))
            return;

        room.gameObject.SetActive(true);
        room.Activate(col.gameObject);
    }
}