using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/EnemyData")]
public class EnemyData : ScriptableObject
{
    public enum MoveStyle { straight, sin, horizontal, tracking };

    public MoveStyle moveStyle;

    public int maxHealth;
    public float speed;
    public float bulletInterval;

    public bool isFire;
}
