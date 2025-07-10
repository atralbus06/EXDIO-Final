using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] ObjectData objectData;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(0, objectData.speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            gameObject.SetActive(false);
        }

        if (objectData.objectType == ObjectData.ObjectType.PlayerBullet && collision.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<Enemy>().Hit(objectData.damage);
            Effect(objectData.TypeNum);
            gameObject.SetActive(false);
        }
    }

    void Effect(string typeNum)
    {
        switch (typeNum)
        {
            case "A":
                GameObject effectA = GameManager.instance.objectManager.Get(3);
                effectA.transform.position = transform.position + new Vector3(0, 0.2f, 0);
                break;
            case "B":
                GameObject effectB = GameManager.instance.objectManager.Get(5);
                effectB.transform.position = transform.position + new Vector3(0, 0.5f, 0);
                break;
        }
    }
}
