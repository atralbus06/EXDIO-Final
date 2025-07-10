using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnArea;

    float spawnTime = 1.0f;
    float spawnInterval = 0.0f;

    void Update()
    {
        spawnInterval += Time.deltaTime;

        if (spawnInterval >= spawnTime)
        {
            spawnInterval = 0.0f;
            Spawn();
        }
    }

    void Spawn()
    {
        int spawnIndex = Random.Range(0, spawnArea.Length);
        GameObject enemy = GameManager.instance.objectManager.Get(2);
        enemy.transform.position = spawnArea[spawnIndex].transform.position;
    }
}
