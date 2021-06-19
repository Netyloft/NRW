using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : Building
{
    public static event Action MainBuildet;
    public static event Action MainDestroy;
    
    protected override void OnBuilt()
    {
        GameMap.PositionMainObject = transform;
        MainBuildet?.Invoke();
    }

    protected override void TakeAway()
    {
        MainDestroy?.Invoke();
        base.TakeAway();
    }
}
