using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    public Waypoint start;
    public Waypoint end;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    Queue<Waypoint> waypointsQueue = new Queue<Waypoint>();
    [SerializeField] bool isEndFound = false;//todo make private
    void LoadTheBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
            //overlapping blocks
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            //add to dictionary
            if(!isOverlapping)
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                print("Adding Waypoint " + grid[waypoint.GetGridPos()] + " to Dictionary");//todo remove later
            }

        }
    }
    private void Start()
    {
        LoadTheBlocks();
        ColourStartAndEnd();
        Pathfind();
    }

    private void Pathfind()//implementation of the BFS algorithm
    {
        print("Enqueing " + grid[start.GetGridPos()]);
        waypointsQueue.Enqueue(grid[start.GetGridPos()]);
        while(waypointsQueue.Count!=0 && !isEndFound)
        {

            Waypoint currentWaypoint = waypointsQueue.Dequeue();
            print("Dequeuing " + currentWaypoint);
            currentWaypoint.isExplored = true;
            isEndFound = HaltIfSearchFound(currentWaypoint);
            ExploreNeighbours(currentWaypoint);

        }
    }

    private bool HaltIfSearchFound(Waypoint currentWaypoint)
    {
        if (currentWaypoint == end)
        {
            print("Found the last waypoint");//todo remove later
            return true;
        }
        return false;
    }

    private void ExploreNeighbours(Waypoint waypoint)
    {
        if(isEndFound)
        {
            return;
        }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = waypoint.GetGridPos() + direction;
            print("Exploring : Cube(" + neighbourCoordinates.x + ", " + neighbourCoordinates.y + ")");
            try
            {
                QueueNewNeighbour(neighbourCoordinates);
            }
            catch
            {

            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if(!neighbour.isExplored)
        {
            neighbour.SetTopColour(Color.blue);
            print("Enqueing neighbour "+neighbour);
            waypointsQueue.Enqueue(neighbour);
        }

    }

    private void ColourStartAndEnd()
    {
        print("Colouring "+start);
        start.SetTopColour(Color.green);
        print("Colouring "+end);
        end.SetTopColour(Color.black);
    }
}
