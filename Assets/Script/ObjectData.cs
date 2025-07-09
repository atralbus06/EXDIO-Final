using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "Scriptable Object/ObjectData")]
public class ObjectData : ScriptableObject
{
    public enum ObjectType { PlayerBullet, EnemyBullet, Item };

    public ObjectType objectType;
    public string TypeNum;

    public float speed;
    public int damage;
}
