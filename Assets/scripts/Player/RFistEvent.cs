using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RFistEvent : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private PlayerStats stats;
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FistAnimation"))
        {
            if (other.name == "enemyCore")
            {
                other.GameObject().transform.parent.GameObject().GetComponent<EnemyFieldOfView>()
                    .TakeDamage((int)stats.AttackPower);
            }
            else if (other.transform.CompareTag("Chest"))
            {
                Debug.Log("Chest hit");
                other.GameObject().GetComponent<chest>().TakeDamage((int)stats.AttackPower);
            }
        }
    }
}
