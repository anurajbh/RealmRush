using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Start is called before the first frame update
    const int gridSize = 10;
    Vector2Int gridPos;
    public int GetGridSize()
    {
        return gridSize;
    }
    // Update is called once per frame
    public Vector2 GetGridPos()
    {
        return new Vector2(
        Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
        Mathf.RoundToInt(transform.position.z / gridSize) * gridSize);
    }
}
