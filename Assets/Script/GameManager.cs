using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //�������� instance�� �ҷ��� �� ���� �ҰŸ� ��ȯ�ϰ� ���̾����Ű�� �ִ� ������Ʈ�� ���;���
    public ObjectManager objectManager;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject enemySemple = objectManager.Get(2);
            enemySemple.transform.position = new Vector2(0, 3);
        }
    }
}
