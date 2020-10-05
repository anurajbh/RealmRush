using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> enemyPath = pathfinder.GetPath();
        StartCoroutine(MoveToWaypoints(enemyPath));
    }

    IEnumerator MoveToWaypoints(List<Waypoint> Path)
    {
        foreach (Waypoint waypoint in Path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}
