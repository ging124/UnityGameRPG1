using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private List<GameObject> waveEnemy;
    [SerializeField]
    private int index = 0;
    [SerializeField]
    private float maxEnemy;

    void Awake()
    {
        waveEnemy = new List<GameObject>();
    }

    void Update()
    {
        Spawn();
        CheckEnemy();
    }

    void Spawn()
    {
        if (waveEnemy.Count >= maxEnemy)
            return;

        Vector3 spawnEnemy = new Vector3(Random.Range(-6, 6), Random.Range(-4, 4), 0);
        GameObject enemy = Instantiate(enemyPrefab, spawnEnemy, Quaternion.identity);
        enemy.name = "Enemy" + index;
        index++;
        if(index > maxEnemy)
        {
            index = 1;
        }
        enemy.GetComponent<FollowPlayer>().enabled = true;
        waveEnemy.Add(enemy);
    }

    void CheckEnemy()
    {
        for (int i = 0; i < waveEnemy.Count; i++)
        {
            if(waveEnemy[i] == null)
            {
                waveEnemy.RemoveAt(i);
            }
        }
    }
}
