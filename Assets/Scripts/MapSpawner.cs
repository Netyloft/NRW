using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject WorldMap;
    public GameObject Graund;

    public GameObject GraundTile;

    public MapObject Tree;
    public MapObject Stone;
    public MapObject Irone;
    public MapObject Spawner;

    public void SpawnMap()
    {
        for (var i = 0; i < GameMap.xLen; i++)
        {
            for (var j = 0; j < GameMap.yLen; j++)
            {
                var mapObject = GameMap.map[i, j] switch
                {
                    MapObjectType.Tree => Instantiate(Tree, new Vector3(i, 0, j), Quaternion.identity),
                    MapObjectType.Stone => Instantiate(Stone, new Vector3(i, 0, j), Quaternion.identity),
                    MapObjectType.Iron => Instantiate(Irone, new Vector3(i, 0, j), Quaternion.identity),
                    MapObjectType.Spawner => Instantiate(Spawner, new Vector3(i, 0, j), Quaternion.identity),
                    _ => null
                };

                if (mapObject != null)
                    mapObject.transform.parent = WorldMap.transform;
                
                
                var ground = Instantiate(GraundTile, new Vector3(i, 0, j), Quaternion.identity).transform;
                ground.parent = Graund.transform;
            }
        }
    }
}