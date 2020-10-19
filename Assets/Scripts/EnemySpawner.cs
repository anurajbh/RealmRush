using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns;
    [SerializeField] EnemyMovement enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemy(enemyPrefab));
    }
    public IEnumerator SpawnEnemy(EnemyMovement enemy)
    {
        while (true)
        {
            EnemyMovement spawnEnemy = Instantiate(enemyPrefab, gameObject.transform) as EnemyMovement;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }
}
