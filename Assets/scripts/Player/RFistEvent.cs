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
        Debug.Log(other.name);
        if (other.name == "enemyCore")
        {
            Debug.Log(other.GameObject().transform.parent.GameObject().name);
        }
        else if (other.transform.CompareTag("Chest"))
        {
            Debug.Log("Chest hit");
            other.GameObject().GetComponent<chest>().TakeDamage((int)stats.AttackPower);
        }
    }
}
