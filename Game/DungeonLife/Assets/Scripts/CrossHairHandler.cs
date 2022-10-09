using UnityEngine;
using UnityEngine.InputSystem;

public class CrossHairHandler : MonoBehaviour
{
    [SerializeField] private CrossHair crossHair;
    [SerializeField] private Transform centerPoint;

    public void Update()
    {
        var vector2 =  Mouse.current.position.ReadValue();
        crossHair.Move(Camera.main.ScreenToWorldPoint(vector2));
    }
}