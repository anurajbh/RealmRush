using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] ParticleSystem selfDestructSystem;
    Text text;
    public float score = 0f;
    [SerializeField] AudioClip damageSFX;
    public VictoryDefeat defeat;
    private void OnTriggerEnter(Collider other)
    {
        Damage(other.gameObject.GetComponentInParent<EnemyMovement>().damage);
        GetComponent<AudioSource>().PlayOneShot(damageSFX);
        CheckForDeath();
    }
    private void Awake()
    {
        text = GameObject.Find("HealthText").GetComponent<Text>();
        HealthDisplay();
    }
    void HealthDisplay()//not planning to call this in Update because it does not need to- best to call it only when there is a change in health
    {
        text.text = health.ToString();
    }
    private void CheckForDeath()
    {
        if(health<=0)
        {
            SelfDestruct(selfDestructSystem);
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        HealthDisplay();
    }
    public void SelfDestruct(ParticleSystem deathParticle)
    {
        ParticleSystem deathVFX = Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        deathVFX.Play();
        Destroy(deathVFX.gameObject, deathVFX.main.duration);
        defeat.gameObject.SetActive(true);
        Time.timeScale = 0;
        Destroy(this.gameObject);
    }
}
