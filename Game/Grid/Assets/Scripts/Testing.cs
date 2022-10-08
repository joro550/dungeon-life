using System;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid _grid;

    private void Start() 
        => _grid = new Grid(4, 4, 10f);

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = GetMousePosition(); // Check the referenced video to get the mouse position
            _grid.SetValue(mousePosition, 56);
        }
    }

    private Vector3 GetMousePosition() 
        => Camera.main.ScreenToWorldPoint(Input.mousePosition);
}