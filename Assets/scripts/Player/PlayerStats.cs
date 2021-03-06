using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float attackPower;
    private float hp;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float maxHp;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCoolDown;
    [SerializeField] private bool isInvincible;
    [SerializeField] private float mouseSpeedX;
    [SerializeField] private float mouseSpeedY;
    private float enemyKilled;
    private float timeInGame;
    [SerializeField] private float gravity;
    [SerializeField] private float groundDistance;
    [SerializeField] private float jumpHeight;
    private float gameStart;
    private bool attacking;

    private void Start()
    {
        gameStart = Time.time;
        hp = maxHp;
    }

    private void Update()
    {
        timeInGame = Time.time - gameStart;
    }

    public bool Attacking
    {
        get => attacking;
        set => attacking = value;
    }
    public float JumpHeight => jumpHeight;
    public float GroundDistance => groundDistance;
    public float Gravity => gravity;

    public float MaxHp => maxHp;
    public float TimeInGame => timeInGame;

    public float Hp
    {
        get => hp;
        set => hp = Math.Max(value, 0);
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

    public float MouseSpeedX => mouseSpeedX;

    public float MouseSpeedY => mouseSpeedY;
}
