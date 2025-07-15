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

    float spawnTimeSub;
    float difficult;
    int spawnNum;

    void Start()
    {
        spawnTime = 0.0f;
        spawnInterval = 1.5f;
        difficult = 20.0f;
    }

    void Update()
    {
        spawnTime += Time.deltaTime;
        spawnTimeSub += Time.deltaTime;
        spawnNum = 0;

        if (GameManager.instance.time >= difficult && spawnInterval > 0.75f)
        {
            difficult = difficult + 20.0f;
            spawnInterval = spawnInterval - 0.25f;
        }

        if (spawnTime >= spawnInterval)
        {
            spawnTime = 0;
            spawnNum = Random.Range(0, 10);
            switch (spawnNum)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    StraightSpawn();
                    break;
                case 4:
                case 5:
                case 6:
                    HorizontalSpawn();
                    break;
                case 7:
                case 8:
                    SinSpawn();
                    break;
                case 9:
                    TrackingSpawn();
                    break;
            }
        }
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
