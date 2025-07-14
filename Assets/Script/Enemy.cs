using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyData enemyData;
    int curHealth;
    float moveTime;
    float bulletSpawnTime;
    public bool isLeft;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        curHealth = enemyData.maxHealth;
        moveTime = 0;
        bulletSpawnTime = 0;
    }

    void Update()
    {
        bulletSpawnTime += Time.deltaTime;
        if (enemyData.isFire && bulletSpawnTime >= enemyData.bulletInterval)
        {
            bulletSpawnTime = 0;
            Fire();
        }
    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        moveTime += Time.fixedDeltaTime;

        switch (enemyData.moveStyle)
        {
            case EnemyData.MoveStyle.straight:
                StraightMove();
                break;
            case EnemyData.MoveStyle.sin:
                SinMove();
                break;
            case EnemyData.MoveStyle.horizontal:
                HorizontalMove();
                break;
            case EnemyData.MoveStyle.tracking:
                trackingMove();
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

    void Fire()
    {
        switch (enemyData.moveStyle)
        {
            case EnemyData.MoveStyle.horizontal:
                GameObject bulletA1 = GameManager.instance.objectManager.Get(8);
                Rigidbody2D rigidA1 = bulletA1.GetComponent<Rigidbody2D>();
                bulletA1.transform.position = transform.position;
                Vector2 directA1 = GameManager.instance.player.transform.position - transform.position;
                rigidA1.velocity = directA1.normalized * bulletA1.GetComponent<Bullet>().objectData.speed;
                break;
            case EnemyData.MoveStyle.tracking:
                GameObject bulletA2 = GameManager.instance.objectManager.Get(8);
                Rigidbody2D rigidA2 = bulletA2.GetComponent<Rigidbody2D>();
                bulletA2.transform.position = transform.position;
                Vector2 directB = GameManager.instance.player.transform.position - transform.position;
                rigidA2.velocity = directB.normalized * bulletA2.GetComponent<Bullet>().objectData.speed;
                break;
        }
    }

    void StraightMove()
    {
        rigid.velocity = new Vector2(0, -enemyData.speed);
    }

    void SinMove()
    {
        if (isLeft)
            rigid.velocity = new Vector2(enemyData.speed, -Mathf.Sin(moveTime + 90) * 5);
        else
            rigid.velocity = new Vector2(-enemyData.speed, -Mathf.Sin(moveTime + 90) * 5);
    }

    void HorizontalMove()
    {
        if (isLeft)
            rigid.velocity = new Vector2(enemyData.speed, 0);
        else
            rigid.velocity = new Vector2(-enemyData.speed, 0);
    }

    void trackingMove()
    {
        Vector2 direct = GameManager.instance.player.transform.position - transform.position;
        rigid.velocity = direct.normalized * enemyData.speed;
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