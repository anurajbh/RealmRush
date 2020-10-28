using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] int secondsBetweenSpawns;
    [SerializeField] EnemyMovement enemyPrefab;
    public int enemyCtr;
    public Text ctrText;
    [SerializeField] AudioClip spawnSFX;
    void Awake()
    {
        ctrText = GameObject.Find("EnemyCounter").GetComponent<Text>();
        DisplayCtr();
        StartCoroutine(SpawnEnemy(enemyPrefab));
    }
    public IEnumerator SpawnEnemy(EnemyMovement enemy)
    {
        while (true)
        {
            EnemyMovement spawnEnemy = Instantiate(enemyPrefab, gameObject.transform) as EnemyMovement;
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            enemyCtr++;
            DisplayCtr();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }
    public void DisplayCtr()
    {
        ctrText.text = enemyCtr.ToString();
    }
}
