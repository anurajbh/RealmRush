using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    public Tower towerPrefab;
    public Queue<Tower> towers = new Queue<Tower>();
    public int towerLimit = 3;
    public void CheckToPlaceTower(Waypoint baseWaypoint)
    {
        if (baseWaypoint.isPlaceable)
        {
            
            if (towers.Count < towerLimit)
            {
                InstantiateTower(baseWaypoint);
            }
            else
            {
                MoveExistingTower(baseWaypoint);
            }
        }

    }
    void InstantiateTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;
        newTower.transform.parent = GameObject.Find("Towers").transform;
        towers.Enqueue(newTower);



    }
    void MoveExistingTower(Waypoint waypoint)
    {
        Tower oldTower = towers.Dequeue();
        oldTower.baseWaypoint.isPlaceable = true;
        waypoint.isPlaceable = false;
        oldTower.baseWaypoint = waypoint;
        oldTower.transform.position = waypoint.transform.position;
        towers.Enqueue(oldTower);
    }
}
