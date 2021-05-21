using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController instance;

    public MapObjectType[,] map;

    public int xLen;
    public int yLen;
    

    private void Awake()
    {
        instance = this;
    }
}
