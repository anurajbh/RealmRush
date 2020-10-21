using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Waypoint> enemyPath = new List<Waypoint>();
    Transform movePoint;
    [SerializeField] float moveSpeed = 10f;
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<Waypoint> enemyPath = pathfinder.GetPath();
        transform.position = enemyPath[0].transform.position;
        StartCoroutine(MoveToWaypoints(enemyPath));
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }
    IEnumerator MoveToWaypoints(List<Waypoint> Path)
    {
        foreach (Waypoint waypoint in Path)
        {
            movePoint = waypoint.transform;
            yield return new WaitUntil(() => isAtPosition(waypoint.transform) == true);
        }
    }
    bool isAtPosition(Transform movePoint)
    {
        if(transform.position==movePoint.position)
        {
            return true;
        }
        return false;
    }
}
