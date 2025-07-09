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
            GameManager.instance.enemy.Hit(objectData.damage);
            gameObject.SetActive(false);
        }
    }
}
