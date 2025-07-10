using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int curHealth;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        maxHealth = 100;
        curHealth = maxHealth;
    }

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