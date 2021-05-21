using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject Map;
    public GameObject Graund;
    
    public GameObject GraundTile;
    public GameObject Tree;
    
    public GameObject Stone;
    public GameObject Irone;

    public void SpawnMap()
    {
        for (var i = 0; i < MapController.instance.xLen; i++)
        {
            for (var j = 0; j < MapController.instance.yLen; j++)
            {
                if (MapController.instance.map[i, j] == MapObjectType.Tree)
                {
                    var tree = Instantiate(Tree, new Vector3(i, 0, j), Quaternion.identity).transform;
                    tree.parent = Map.transform;
                }
                
                if (MapController.instance.map[i, j] == MapObjectType.Stone)
                {
                    var tree = Instantiate(Stone, new Vector3(i, 0, j), Quaternion.identity).transform;
                    tree.parent = Map.transform;
                }
                
                if (MapController.instance.map[i, j] == MapObjectType.Iron)
                {
                    var tree = Instantiate(Irone, new Vector3(i, 0, j), Quaternion.identity).transform;
                    tree.parent = Map.transform;
                }
                
                var graund = Instantiate(GraundTile, new Vector3(i, 0, j), Quaternion.identity).transform;
                graund.parent = Graund.transform;
            }
        }
        
        
        //Graund.GetComponent<MeshCombiner>().CombineMeshes(true);
    }
}
