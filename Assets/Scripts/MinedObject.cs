using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MinedObject : MapObject
{
    [SerializeField] private int maxResources;
    [SerializeField] private int currentResources;
    [SerializeField] public MapObjectType type;
    
    void Start()
    {
        currentResources = maxResources;
    }

    public void Mine(int count)
    {
        currentResources -= count;
        
        ResourseCounter.counter.ChangeResource(type, count);
        
        if(currentResources <= 0)
            TakeAway();
    }
}
