using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
        void Start(){}
    private void OnControllerColliderHit(ControllerColliderHit coll)
    {
<<<<<<< HEAD
        // Debug.Log(coll.transform.tag);
=======
        //Debug.Log(coll.transform.tag);
>>>>>>> 32b20f35f8e321ae7139a8d40b7ffa5ae1d7b289
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
