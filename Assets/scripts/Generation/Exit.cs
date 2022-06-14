using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
        void Start(){}
    private void OnControllerColliderHit(ControllerColliderHit coll)
    {
        Debug.Log(coll.transform.tag);
        if (coll.transform.tag == "Exit")
        {
            Destroy(TerrainGeneration.boardHolderBlocks.gameObject);
            Destroy(TerrainGeneration.boardHolderOther.gameObject);
            Destroy(TerrainGeneration.boardHolderTrap.gameObject);
            Destroy(TerrainGeneration.boardHolderEntities.gameObject);

            TerrainGeneration.genLevel = true;
        }
    }
}
