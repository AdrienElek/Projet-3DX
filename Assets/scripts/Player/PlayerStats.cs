using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float attackPower;
    [SerializeField] private float hp;
    [SerializeField] private float playerSpeed;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCoolDown;
    [SerializeField] private bool isInvincible;
    private float enemyKilled;
    [SerializeField] private float timeInGame;
    private float gameStart;

    private void Start()
    {
        gameStart = Time.time;
    }

    private void Update()
    {
        timeInGame = Time.time - gameStart;
    }

    public float TimeInGame => timeInGame;

    public float Hp
    {
        get => hp;
        set => hp = value;
    }

    public float AttackPower
    {
        get => attackPower;
        set => attackPower = value;
    }

    public float PlayerSpeed => playerSpeed;

    public float DashSpeed => dashSpeed;

    public float DashTime => dashTime;

    public float DashCoolDown => dashCoolDown;

    public bool IsInvincible
    {
        get => isInvincible;
        set => isInvincible = value;
    }

    public float EnemyKilled
    {
        get => enemyKilled;
        set => enemyKilled = value;
    }
}
