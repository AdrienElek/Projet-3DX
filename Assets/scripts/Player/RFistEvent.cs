using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RFistEvent : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float damage;
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "enemyCore")
        {
            Debug.Log(other.GameObject().transform.parent.GameObject().name);
        }
    }
}
