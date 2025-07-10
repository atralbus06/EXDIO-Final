using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //프리팹은 instance로 불러올 수 없음 할거면 소환하고 하이어라이키에 있는 오브젝트를 들고와야함
    public ObjectManager objectManager;

    public string[] playerBulletType;
    public string curPlayerBulletType;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        curPlayerBulletType = "A";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject enemySemple = objectManager.Get(2);
            enemySemple.transform.position = new Vector2(0, 3);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeBullet();
        }
        
    }

    void ChangeBullet()
    {
        for (int i = 0; i < playerBulletType.Length; i++)
        {
            if (playerBulletType[i] == curPlayerBulletType)
            {
                if (i == playerBulletType.Length - 1)
                    curPlayerBulletType = playerBulletType[0];
                else
                    curPlayerBulletType = playerBulletType[i + 1];
                break;
            }
        }
    }
}
