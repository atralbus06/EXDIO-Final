using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Scriptable Object/EnemyData")]
public class EnemyData : ScriptableObject
{
    public enum MoveStyle { straight, sin, tan };

    public MoveStyle moveStyle;

    public int maxHealth;
    public float speed;

    public bool isReverse;
    public bool isFire;
}
