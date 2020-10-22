using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{
    public float HP = 10f;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticle;
    public ParticleSystem endParticle;
    public void CheckForDeath()
    {
        if(HP <= 0f)
        {
            SelfDestruct(deathParticle);
        }
    }

    public void SelfDestruct(ParticleSystem deathParticle)
    {
        ParticleSystem deathVFX = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        deathVFX.Play();
        EnemySpawner.Instance.enemyCtr--;
        EnemySpawner.Instance.DisplayCtr();
        Destroy(deathVFX.gameObject, deathVFX.main.duration);
        Destroy(this.gameObject);
    }

    public void DamageEnemy(float affect)
    {
        HP -= affect;
        CheckForDeath();
        hitParticlePrefab.Play();
    }
    public void OnParticleCollision(GameObject other)
    {
        DamageEnemy(1f);
    }
}
