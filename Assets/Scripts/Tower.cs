using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform panObject;
    [SerializeField] Transform objectToLookAt;
    [SerializeField] float firingRange = 10f;
    [SerializeField] ParticleSystem bullets;
    void Update()
    {
        if (objectToLookAt)
        {
            LookAtEnemy(objectToLookAt);
        }
        else
        {
            Shoot(false);
        }

    }
    public void LookAtEnemy(Transform objectToLook)
    {
        panObject.LookAt(objectToLook);
        CheckIfShouldShoot(objectToLook);
        
    }
    void CheckIfShouldShoot(Transform objectToShoot)
    {
        if (Vector3.Distance(objectToShoot.position, gameObject.transform.position) <= firingRange)
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
