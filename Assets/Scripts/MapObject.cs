using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MapObject : MonoBehaviour
{

    [SerializeField] private int maxHp;
    [SerializeField] private int currentHp;
    
    
    private int minedResources;
    
    void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        
        if(currentHp <= 0)
            TakeAway();
    }
    
    protected void TakeAway()
    {
        gameObject.SetActive(false);
        NavMeshBakingDish.BakingDish.Baking();
        Destroy(gameObject);
    }
}
