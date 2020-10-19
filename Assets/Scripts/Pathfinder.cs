using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    public Waypoint startWaypoint;
    public Waypoint endWaypoint;
    Vector2Int[] directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };
    Queue<Waypoint> waypointsQueue = new Queue<Waypoint>();
    bool isEndFound = false;
    Waypoint currentWaypoint;
    List<Waypoint> path = new List<Waypoint>();
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
            }

        }
    }
    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculateThePath();
        }
        return path;
    }

    private void CalculateThePath()
    {
        startWaypoint.exploredFrom = startWaypoint;
        LoadTheBlocks();
        ColourStartAndEnd();
        BreadthFirstSearch();
        CreateThePath();
    }

    private void CreateThePath()
    {
        path.Add(endWaypoint);
        Waypoint previousWaypoint = endWaypoint.exploredFrom;
        while(previousWaypoint!=startWaypoint)
        {
            path.Add(previousWaypoint);
            previousWaypoint = previousWaypoint.exploredFrom;
        }
        path.Add(previousWaypoint);
        path.Reverse();
    }

    private void BreadthFirstSearch()//implementation of the BFS algorithm
    {
        waypointsQueue.Enqueue(grid[startWaypoint.GetGridPos()]);
        while(waypointsQueue.Count!=0 && !isEndFound)
        {

            currentWaypoint = waypointsQueue.Dequeue();
            currentWaypoint.isExplored = true;
            isEndFound = HaltIfSearchFound();
            ExploreNeighbours();

        }
    }

    private bool HaltIfSearchFound()
    {
        if (currentWaypoint == endWaypoint)
        {
            return true;
        }
        return false;
    }

    private void ExploreNeighbours()
    {
        if(isEndFound)
        {
            return;
        }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = currentWaypoint.GetGridPos() + direction;
            if(grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbour(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if(!neighbour.isExplored && !waypointsQueue.Contains(neighbour))
        {
            waypointsQueue.Enqueue(neighbour);
            neighbour.exploredFrom = currentWaypoint;
        }

    }

    private void ColourStartAndEnd()
    {
        //todo consider moving to waypoint
        startWaypoint.SetTopColour(Color.green);
        endWaypoint.SetTopColour(Color.black);
    }
}
