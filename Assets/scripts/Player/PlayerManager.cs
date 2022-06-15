using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerStats))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerStats stats;
    [SerializeField] private PlayerHUD hud;
    public void TakeDamage(float damage)
    {
        stats.Hp -= damage;
        hud.SetHealth(stats.Hp);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
