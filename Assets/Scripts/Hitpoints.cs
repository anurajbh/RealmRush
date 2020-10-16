using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{
    public float HP;
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
    }
    public void OnParticleCollision(GameObject other)
    {
        print("Lol Im hit");
    }
}
