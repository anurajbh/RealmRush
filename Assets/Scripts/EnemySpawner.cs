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
    Text text;
    public static EnemySpawner Instance;
    [SerializeField] AudioClip spawnSFX;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        text = GameObject.Find("EnemyCounter").GetComponent<Text>();
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
        text.text = enemyCtr.ToString();
    }
}
