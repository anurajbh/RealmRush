﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //public okay here as this is a data class
    public Waypoint exploredFrom;
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public int GetGridSize()
    {
        return gridSize;
    }
    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
        Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }
    public void SetTopColour(Color color)
    {
        MeshRenderer meshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;
    }
    public void Update()
    {
        if(exploredFrom)
        {
            this.SetTopColour(Color.blue);//todo remove entirely
        }
    }
}
