using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{
    public float HP = 10f;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticle;
    public void CheckForDeath()
    {
        if(HP <= 0f)
        {
            ParticleSystem deathVFX = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
            deathVFX.Play();
            Destroy(gameObject);
        }
    }
    public void AffectThisObject(float affect)
    {
        HP += affect;
        CheckForDeath();
        hitParticlePrefab.Play();
    }
    public void OnParticleCollision(GameObject other)
    {
        AffectThisObject(-1f);
    }
}
