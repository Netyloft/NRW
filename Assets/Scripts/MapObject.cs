using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MapObject : MonoBehaviour
{

    [SerializeField] private int maxHp;
    [SerializeField] private int currentHp;
    [SerializeField] private int maxResources;
    [SerializeField] private int currentResources;
    [SerializeField] public MapObjectType type;
    
    private int minedResources;
    
    void Start()
    {
        currentHp = maxHp;
        currentResources = maxResources;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        
        if(currentHp <= 0)
            TakeAway();
    }
    
    public void Mine(int count)
    {
        currentResources -= count;
        
        ResourseCounter.counter.ChangeResource(type, 10);
        
        if(currentResources <= 0)
            TakeAway();
    }

    protected void TakeAway()
    {
        gameObject.SetActive(false);
        NavMeshBakingDish.BakingDish.Baking();
        Destroy(gameObject);
    }
}
