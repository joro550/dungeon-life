using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool isOpen;
    private static readonly int Open = Animator.StringToHash("Open");

    public void OpenDoor()
    {
        animator.SetTrigger(Open);
        isOpen = true;
    }
}