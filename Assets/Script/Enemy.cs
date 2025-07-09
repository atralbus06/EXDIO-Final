using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int maxHealth;
    int curHealth;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;

    void Awake()
    {
        maxHealth = 100;
        curHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    //void OnEnable()
    //{
    //    curHealth = maxHealth;
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            gameObject.SetActive(false);
        }
    }

    public void Hit(int damage)
    {
        curHealth -= damage;
        Debug.Log("Hit! curHealth : " + curHealth);
    }
}