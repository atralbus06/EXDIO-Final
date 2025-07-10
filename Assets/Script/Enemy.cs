using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    int curHealth;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        curHealth = enemyData.maxHealth;
    }

    void FixedUpdate()
    {
        switch (enemyData.moveStyle)
        {
            case EnemyData.MoveStyle.straight:
                Straight();
                break;
            case EnemyData.MoveStyle.sin:
                break;
            case EnemyData.MoveStyle.tan:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            gameObject.SetActive(false);
        }
    }

    void Straight()
    {
        if (enemyData.isReverse)
            rigid.velocity = new Vector2(0, -enemyData.speed);
        else
            rigid.velocity = new Vector2(0, enemyData.speed);
    }

    public void Hit(int damage)
    {
        curHealth -= damage;
        Debug.Log("Hit! curHealth : " + curHealth);

        if (curHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}