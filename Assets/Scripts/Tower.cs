using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform panObject;

    [SerializeField] float firingRange = 10f;
    [SerializeField] ParticleSystem bullets;

    //State of each tower
    Transform objectToLookAt;
    public Waypoint baseWaypoint;
    void Update()
    {
        objectToLookAt = SetTargetEnemy();
        if (objectToLookAt)
        {
            LookAtEnemy(objectToLookAt);
        }
        else
        {
            Shoot(false);
        }

    }

    private Transform SetTargetEnemy()
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
        if(enemies.Length==0)
        {
            return null;
        }
        Transform closestEnemy = enemies[0].transform;
        for(int i =0; i<enemies.Length;i++)
        {
            if(Vector3.Distance(gameObject.transform.position, enemies[i].transform.position) < Vector3.Distance(gameObject.transform.position, closestEnemy.position))
            {
                closestEnemy = enemies[i].transform;
            }
        }
        return closestEnemy;
    }

    public void LookAtEnemy(Transform objectToLook)
    {
        panObject.LookAt(objectToLook);
        CheckIfShouldShoot(objectToLook);
        
    }
    void CheckIfShouldShoot(Transform objectToShoot)
    {
        if (Vector3.Distance(gameObject.transform.position, objectToShoot.position) <= firingRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }
    void Shoot(bool v)
    {
        ParticleSystem.EmissionModule emissionModule = bullets.emission;
        emissionModule.enabled = v;
    }
}
