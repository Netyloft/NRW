using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offset;
    public float zoom;
    public int seed;
    [Range(0, 1)] public float intencity;
    
    
    
    
    private MapSpawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<MapSpawner>();
    }

    void Start()
    {
        CreateNewMap();
    }

    public void CreateNewMap()
    {
        seed = Random.Range(0, 500000);
        var r = DungeonMapGenerator(size.x + 5, size.y + 5, intencity);
        _spawner.SpawnMap(r);
        
    }
    
    private MapObjectType[,] DungeonMapGenerator(int x, int y, float range)
    {
        var map = new MapObjectType[x, y];

        for (var i = 0; i < x; i++)
        {
            for (var j = 0; j < y; j++)
            {
                var gr = Mathf.PerlinNoise((i + offset.x * seed + 5) / zoom, (j + offset.y * seed) / zoom);

                if (i == 0 || j == 0 || i == x - 1 || j == y - 1)
                {
                    map[i, j] = MapObjectType.Tree;
                    continue;
                }

                if (gr < range)
                {
                    map[i, j] = MapObjectType.Tree;
                    continue;
                }
                
                map[i, j] = MapObjectType.Graund;
            }
        }

        return map;
    }

    
}
