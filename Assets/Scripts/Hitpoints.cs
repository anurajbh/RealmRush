using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{
    public float HP = 10f;
    public void CheckForDeath()
    {
        if(HP <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void AffectThisObject(float affect)
    {
        HP += affect;
        CheckForDeath();
    }
    public void OnParticleCollision(GameObject other)
    {
        AffectThisObject(-1f);
        print("Current HP is : " + HP);
    }
}
