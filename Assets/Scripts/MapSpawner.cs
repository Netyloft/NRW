using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject Map;
    
    public GameObject Graund;
    public GameObject Tree;
    public void SpawnMap(MapObjectType[,] map)
    {
        var xLen = map.GetLength(0);
        var yLen = map.GetLength(1);
        
        for (var i = 0; i < xLen; i++)
        {
            for (var j = 0; j < yLen; j++)
            {
                if (map[i, j] == MapObjectType.Tree)
                {
                    var tree = Instantiate(Tree, new Vector3(i, 0, j), Quaternion.identity).transform;
                    tree.parent = Map.transform;
                }
                
                var graund = Instantiate(Graund, new Vector3(i, 0, j), Quaternion.identity).transform;
                graund.parent = Map.transform;
            }
        }
    }
}
