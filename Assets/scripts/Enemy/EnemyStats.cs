using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float attackPower;
    private float hp;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float maxHp;

    public float timeBetweenAttacks;

    private void Start()
    {
        hp = maxHp;
    }

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public float AttackPower
    {
        get { return attackPower; }
        set { attackPower = value; }
    }

    public float EnemySpeed => enemySpeed;

    public float TimeBetweenAttacks
    {
        get { return timeBetweenAttacks; }
        set { timeBetweenAttacks = value; }
    }
}
