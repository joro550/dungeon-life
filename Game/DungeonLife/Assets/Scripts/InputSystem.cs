using Event;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [Header("Mouse")]
    [SerializeField] private GameEvent onLeftMouseDown;
    [SerializeField] private GameEvent onLeftMouseUp;
    
    [SerializeField] private GameEvent onRightMouseDown;
    [SerializeField] private GameEvent onRightMouseUp;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) onLeftMouseDown.Raise();
        if (Input.GetMouseButtonUp(0)) onLeftMouseUp.Raise();
        if (Input.GetMouseButtonDown(1)) onRightMouseDown.Raise();
        if (Input.GetMouseButtonUp(1)) onRightMouseUp.Raise();
    }

}