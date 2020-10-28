using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitpoints : MonoBehaviour
{
    public float HP = 10f;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticle;
    public ParticleSystem endParticle;
    [SerializeField] AudioClip damageSFX;
    [SerializeField] AudioClip deathSFX;
    public EnemySpawner enemySpawner;
    public void CheckForDeath()
    {
        if(HP <= 0f)
        {
            SelfDestruct(deathParticle);
        }
    }
    private void Awake()
    {
        enemySpawner = GameObject.Find("Enemies").GetComponent<EnemySpawner>();
    }
    public void SelfDestruct(ParticleSystem deathParticle)
    {
        ParticleSystem deathVFX = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        deathVFX.Play();
        enemySpawner.enemyCtr--;
        enemySpawner.DisplayCtr();
        Destroy(deathVFX.gameObject, deathVFX.main.duration);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        Destroy(this.gameObject);
    }

    public void DamageEnemy(float affect)
    {
        GetComponent<AudioSource>().PlayOneShot(damageSFX);
        HP -= affect;
        CheckForDeath();
        hitParticlePrefab.Play();
    }
    public void OnParticleCollision(GameObject other)
    {
        DamageEnemy(1f);
    }
}
