using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBakingDish : MonoBehaviour
{
    public static NavMeshBakingDish BakingDish;
    private NavMeshSurface _navMeshSurface;
    
    public void Awake()
    {
        BakingDish = this;
        _navMeshSurface = GetComponent<NavMeshSurface>();
    }

    public void Baking()
    {
        _navMeshSurface.BuildNavMesh();
    }
    
    public void Updating()
    {
        _navMeshSurface.UpdateNavMesh(_navMeshSurface.navMeshData);
    }

    private void OnEnable()
    {
        MapObject.OnTakeAway += Baking;
    }
    
    private void OnDisable()
    {
        MapObject.OnTakeAway -= Baking;
    }
}
