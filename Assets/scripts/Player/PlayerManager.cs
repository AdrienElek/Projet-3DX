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
        if (stats.Hp == 0)
        {
            restart();   
        }
            
    }
    public void restart()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
}
