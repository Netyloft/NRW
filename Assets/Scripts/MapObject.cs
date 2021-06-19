using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField] private int currentHp;

    public static event Action OnTakeAway;
    
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
        Debug.Log("Вызывает");
        GameMap.map[(int) transform.position.x, (int) transform.position.z] = MapObjectType.Graund;
        gameObject.SetActive(false);
        //OnTakeAway?.BeginInvoke(null, null);
        NavMeshBakingDish.BakingDish.Updating();
        Destroy(gameObject);
    }
}
