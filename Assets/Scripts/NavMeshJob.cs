using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.AI;

public struct NavMeshJob : IJob
{
    public NativeArray<int> NativeArray;
        
    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}
