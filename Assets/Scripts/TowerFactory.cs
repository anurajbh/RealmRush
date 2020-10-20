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
            
            if (towers.Count <= towerLimit)
            {
                InstantiateTower(baseWaypoint);
            }
            else
            {
                MoveExistingTower(baseWaypoint);
            }
        }

        else if(!baseWaypoint.isPlaceable)
        {
            print("Can't place here lol");
        }
    }
    void MoveExistingTower(Waypoint waypoint)
    {
        Debug.Log("Limit reached");
    }
    private void InstantiateTower(Waypoint baseWaypoint)
    {
        Tower newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        towers.Enqueue(newTower);
        newTower.transform.parent = GameObject.Find("Towers").transform;
        baseWaypoint.isPlaceable = false;
    }
}
