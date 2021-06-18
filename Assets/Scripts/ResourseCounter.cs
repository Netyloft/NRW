using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ResourseCounter : MonoBehaviour
{
    public static ResourseCounter counter;
    
    [SerializeField] private int WoodCount;
    [SerializeField] private int StoneCount;
    [SerializeField] private int IronCount;
    // Start is called before the first frame update

    public delegate void ResourcesСhanged(int woodCount, int stoneCount, int ironCount);
    public static event ResourcesСhanged Change;
    private void Awake()
    {
        counter = this;
    }

    private void Start()
    {
        Change?.Invoke(WoodCount, StoneCount, IronCount);
    }

    public bool CheckResourceAvailability(int wood, int stone, int iron)
    {
        if (WoodCount < wood || StoneCount < stone || IronCount < iron) return false;
        
        return true;
    }

    public void ChangeResource(MapObjectType type, int count)
    {
        switch (type)
        {
            case MapObjectType.Tree:
                WoodCount += count;
                break;
            case MapObjectType.Stone:
                StoneCount += count;
                break;
            case MapObjectType.Iron:
                IronCount += count;
                break;
        }
        
        Change?.Invoke(WoodCount, StoneCount, IronCount);
    }
}
