using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using LevelGen;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Trap : MonoBehaviour
{
    public GameObject barrel;
    public int height = 4;
    public bool triger = true;
    public void Start(){}
    private void OnConTriggerStay(ControllerColliderHit coll)
    {
        Debug.Log("You Fell into a Trap !!");
        GameObject barr = Instantiate(barrel,  new Vector3(this.transform.position.x, this.transform.position.y + height, this.transform.position.z), Quaternion.identity);
        barr.transform.SetParent(TerrainGeneration.boardHolderTrap);
        triger = false;
    }
}
