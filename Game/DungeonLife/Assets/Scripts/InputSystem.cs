using UnityEngine;
using Event.Events;

public class InputSystem : MonoBehaviour
{
    [Header("Mouse")]
    [SerializeField] private VoidEvent onLeftMouseDown;
    [SerializeField] private VoidEvent onLeftMouseUp;
    
    [SerializeField] private VoidEvent onRightMouseDown;
    [SerializeField] private VoidEvent onRightMouseUp;

    public void Update()
    {
        // if (Input.GetMouseButtonDown(0)) onLeftMouseDown.Raise();
        // if (Input.GetMouseButtonUp(0)) onLeftMouseUp.Raise();
        // if (Input.GetMouseButtonDown(1)) onRightMouseDown.Raise();
        // if (Input.GetMouseButtonUp(1)) onRightMouseUp.Raise();
    }

}