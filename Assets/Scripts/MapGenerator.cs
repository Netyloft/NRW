using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offset;
    public float zoom;
    public int seed;
    [Range(0, 1)] public float intencity;

    public int StoneCount;
    public int IronCount;
    
    private MapSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<MapSpawner>();
    }

    void Start()
    {
        CreateNewMap();
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }

    public void CreateNewMap()
    {
        seed = Random.Range(0, 500000);
        DungeonMapGenerator(size.x + 5, size.y + 5, intencity);

        ArrangeMineObjects(MapObjectType.Stone, StoneCount);
        ArrangeMineObjects(MapObjectType.Iron, IronCount);
        
        _spawner.SpawnMap();
        
    }
    
    private void DungeonMapGenerator(int x, int y, float range)
    {
        MapController.instance.map = new MapObjectType[x, y];
        MapController.instance.xLen = x;
        MapController.instance.yLen = y;

        for (var i = 0; i < x; i++)
        {
            for (var j = 0; j < y; j++)
            {
                var gr = Mathf.PerlinNoise((i + offset.x * seed + 5) / zoom, (j + offset.y * seed) / zoom);

                if (i == 0 || j == 0 || i == x - 1 || j == y - 1)
                {
                    MapController.instance.map[i, j] = MapObjectType.Tree;
                    continue;
                }

                if (gr < range)
                {
                    MapController.instance.map[i, j] = MapObjectType.Tree;
                    continue;
                }
                
                MapController.instance.map[i, j] = MapObjectType.Graund;
            }
        }
    }

    private void ArrangeMineObjects(MapObjectType type, int count)
    {
        var cou = 0;

        while (count != cou)
        {
            var x = Random.Range(0, MapController.instance.xLen);
            var y = Random.Range(0, MapController.instance.yLen);

            if (MapController.instance.map[x, y] != MapObjectType.Graund) continue;
            
            MapController.instance.map[x, y] = type;
            cou++;
        }
    }
    
}
