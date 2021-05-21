using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.AI;

public class MapController : MonoBehaviour
{
    public static MapController instance;

    public MapObjectType[,] map;

    public int xLen;
    public int yLen;
    private NavMeshSurface _navMeshSurface;


    private void Start()
    {
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    private void Awake()
    {
        instance = this;
    }

    public void Build()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
