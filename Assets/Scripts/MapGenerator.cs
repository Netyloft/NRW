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
        var r = DungeonMapGenerator(size.x + 5, size.y + 5, intencity);

        r = ArrangeMineObjects(r, MapObjectType.Stone, StoneCount);
        r = ArrangeMineObjects(r, MapObjectType.Iron, IronCount);
        
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

    private MapObjectType[,] ArrangeMineObjects(MapObjectType[,] map, MapObjectType type, int count)
    {
        var cou = 0;

        var xLen = map.GetLength(0);
        var yLen = map.GetLength(1);
        
        while (count != cou)
        {
            var x = Random.Range(0, xLen);
            var y = Random.Range(0, yLen);

            if (map[x, y] != MapObjectType.Graund) continue;
            
            map[x, y] = type;
            cou++;
        }
        
        return map;
    }
    
}
