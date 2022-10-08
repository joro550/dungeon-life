using TMPro;
using UnityEngine;

public class Grid 
{
    private readonly int _width;
    private readonly int _height;
    private readonly float _cellSize;

    private readonly int[,] _gridArray;
    private readonly TextMesh[,] _textMeshes;

    public Grid(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;

        _gridArray = new int[width, height];
        _textMeshes = new TextMesh[width, height];

        for (var x = 0; x < _gridArray.GetLength(0); x++)
        {
            for (var y = 0; y < _gridArray.GetLength(1); y++)
            {
                _textMeshes[x,y] = CreateWorldText(_gridArray[x,y].ToString(), null, GetWorldPosition(x,y) + new Vector3(cellSize, cellSize) * .5f, 20, Color.white);
                Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y+1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x,y ), GetWorldPosition(x+1, y), Color.white, 100f);
            }
        }
        
        Debug.DrawLine(GetWorldPosition(0,height ), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,0 ), GetWorldPosition(width, height), Color.white, 100f);

        SetValue(2, 1, 56);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize;
    }

    private Vector2Int GetXY(Vector3 worldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(worldPosition.x / _cellSize),
            Mathf.FloorToInt(worldPosition.y / _cellSize));
    }

    public void SetValue(int x, int y, int value)
    {
        if (x < 0 || y < 0 || x >= _width || y >= _height) 
            return;
        
        _gridArray[x, y] = value;
        _textMeshes[x, y].text = _gridArray[x, y].ToString();
    }

    public void SetValue(Vector3 worldPosition, int value)
    {
        var vector2 = GetXY(worldPosition);
        SetValue(vector2.x, vector2.y, value);
    }

    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default, int fontSize = 40,
        Color? color = null, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Center, int sortingOrder = 0)
    {
        color ??= Color.white;
        return CreateWorldText(parent, text, localPosition, fontSize, color.Value, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize,
        Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform t = gameObject.transform;
        t.SetParent(parent);
        t.localPosition = localPosition;

        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }
}
