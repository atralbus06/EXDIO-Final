using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] straightSpawnArea;
    [SerializeField] GameObject[] sinSpawnArea;
    [SerializeField] GameObject[] horizontalSpawnArea;
    [SerializeField] GameObject[] trackingSpawnArea;

    float spawnTime = 1.0f;
    float spawnInterval = 0.0f;

    void Update()
    {
        spawnInterval += Time.deltaTime;

        if (spawnInterval >= spawnTime)
        {
            spawnInterval = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            StraightSpawn();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SinSpawn();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            HorizontalSpawn();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            TrackingSpawn();
    }

    void StraightSpawn()
    {
        int spawnIndex = Random.Range(0, straightSpawnArea.Length);
        GameObject enemy = GameManager.instance.objectManager.Get(2);
        enemy.transform.position = straightSpawnArea[spawnIndex].transform.position;
    }

    void SinSpawn()
    {
        int spawnIndex = Random.Range(0, sinSpawnArea.Length);
        GameObject enemy = GameManager.instance.objectManager.Get(6);
        enemy.transform.position = sinSpawnArea[spawnIndex].transform.position;

        if (spawnIndex == 1)
            enemy.GetComponent<Enemy>().isLeft = true;
        else
            enemy.GetComponent<Enemy>().isLeft = false;
    }

    void HorizontalSpawn()
    {
        int spawnIndex = Random.Range(0, horizontalSpawnArea.Length);
        GameObject enemy = GameManager.instance.objectManager.Get(7);
        enemy.transform.position = horizontalSpawnArea[spawnIndex].transform.position;

        if (spawnIndex % 2 == 0)
            enemy.GetComponent<Enemy>().isLeft = true;
        else
            enemy.GetComponent<Enemy>().isLeft = false;
    }

    void TrackingSpawn()
    {
        int spawnIndex = Random.Range(0, trackingSpawnArea.Length);
        GameObject enemy = GameManager.instance.objectManager.Get(9);
        enemy.transform.position = straightSpawnArea[spawnIndex].transform.position;
    }
}
