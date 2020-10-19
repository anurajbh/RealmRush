using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //public okay here as this is a data class
    public Waypoint exploredFrom;
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public bool isPlaceable = true;
    public Tower towerPrefab;
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
    private void OnMouseOver()
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
            if(isPlaceable)
            {
                print("Can place at " + gameObject.name);
                Tower newTower = Instantiate(towerPrefab, gameObject.transform.position, Quaternion.identity);
                newTower.transform.parent = GameObject.Find("Towers").transform;
                isPlaceable = false;
            }

            else
            {
                print("Can't place here lol");
            }

        }
        
    }
}
