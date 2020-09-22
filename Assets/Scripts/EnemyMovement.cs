using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Waypoint> Path;
    void Start()
    {
        StartCoroutine(MoveToWaypoints());
    }

    IEnumerator MoveToWaypoints()
    {
        print("Starting patrol");
        foreach (Waypoint waypoint in Path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting waypoint : " + waypoint.gameObject.name);
            yield return new WaitForSeconds(1f);
        }
    }
}
