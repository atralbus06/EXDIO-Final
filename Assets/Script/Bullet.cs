using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        speed = 7.5f;
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(0, speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeadZone")
        {
            gameObject.SetActive(false);
        }

        if (collision.tag == "Enemy")
        {
            GameManager.instance.enemy.Hit();
            gameObject.SetActive(false);
        }
    }
}
