using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerStats))]
public class PlayerHUD : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private PlayerStats stats;


    private void Start()
    {
        SetMaxHealth(stats.MaxHp);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
