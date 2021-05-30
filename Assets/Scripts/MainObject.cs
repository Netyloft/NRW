using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : Building
{
    public delegate void Built();

    public static event Built MainBuildet;
    protected override void OnBuilt()
    {
        GameMap.PositionMainObject = transform;
        MainBuildet?.Invoke();
    }
}
