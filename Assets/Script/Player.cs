using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    float speed;
    float bulletInterval;
    float bulletSpawnTime;

    bool isTouchTop;
    bool isTouchBottom;
    bool isTouchRight;
    bool isTouchLeft;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        speed = 5;
        bulletInterval = 0.25f;
        bulletSpawnTime = 0.0f;

        isTouchTop = false;
        isTouchBottom = false;
        isTouchRight = false;
        isTouchLeft = false;
    }

    void Update()
    {
        Attack();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerMoveArea")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }

        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            GameManager.instance.GameOver();
            Time.timeScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerMoveArea")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

        float v = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            v = 0;

        rigid.velocity = new Vector2(h, v).normalized * speed;
    }

    void Attack()
    {
        bulletSpawnTime += Time.deltaTime;

        if (bulletSpawnTime >= bulletInterval)
        {
            bulletSpawnTime = 0.0f;

            switch (GameManager.instance.curPlayerBulletType)
            {
                case "A":
                    GameObject playerBulletA = GameManager.instance.objectManager.Get(1);
                    playerBulletA.transform.position = transform.position + new Vector3(0, 0.5f, 0);
                    break;
                case "B":
                    GameObject playerBulletB = GameManager.instance.objectManager.Get(4);
                    playerBulletB.transform.position = transform.position + new Vector3(0, 0.5f, 0);
                    break;

            }
        }
    }

    public void ChangeInterval(string bulletType)
    {
        switch (bulletType)
        {
            case "A":
                bulletInterval = 0.5f;
                break;
            case "B":
                bulletInterval = 1.0f;
                break;
        }
    }
}
