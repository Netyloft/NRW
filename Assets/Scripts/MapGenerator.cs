using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Vector2Int _size;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _zoom;
    [SerializeField] private int _seed;
    [SerializeField, Range(0, 1)] private float _intencity;

    [SerializeField] private int _stoneCountOnMap;
    [SerializeField] private int _ironCountOnMap;
    [SerializeField] private int _spawnersCountOnMap;
    
    private MapSpawner _spawner;
    
    private void Awake()
    {
        _spawner = GetComponent<MapSpawner>();
    }

    void Start()
    {
        CreateNewMap();
        NavMeshBakingDish.BakingDish.Baking();
    }

    public void CreateNewMap()
    {
        _seed = Random.Range(0, 500000);
        DungeonMapGenerator(_size.x + 5, _size.y + 5, _intencity);

        ArrangeMineObjects(MapObjectType.Stone, _stoneCountOnMap);
        ArrangeMineObjects(MapObjectType.Iron, _ironCountOnMap);
        ArrangeMineObjects(MapObjectType.Spawner, _spawnersCountOnMap);
        
        _spawner.SpawnMap();
        
    }
    
    private void DungeonMapGenerator(int x, int y, float range)
    {
        GameMap.map = new MapObjectType[x, y];
        GameMap.xLen = x;
        GameMap.yLen = y;

        for (var i = 0; i < x; i++)
        {
            for (var j = 0; j < y; j++)
            {
                var gr = Mathf.PerlinNoise((i + _offset.x * _seed + 5) / _zoom, (j + _offset.y * _seed) / _zoom);

                if (i == 0 || j == 0 || i == x - 1 || j == y - 1)
                {
                    GameMap.map[i, j] = MapObjectType.Tree;
                    continue;
                }

                if (gr < range)
                {
                    GameMap.map[i, j] = MapObjectType.Tree;
                    continue;
                }
                
                GameMap.map[i, j] = MapObjectType.Graund;
            }
        }
    }

    private void ArrangeMineObjects(MapObjectType type, int count)
    {
        var cou = 0;

        while (count != cou)
        {
            var x = Random.Range(0, GameMap.xLen);
            var y = Random.Range(0, GameMap.yLen);

            if (GameMap.map[x, y] != MapObjectType.Graund) continue;
            
            GameMap.map[x, y] = type;
            cou++;
        }
    }
    
}
