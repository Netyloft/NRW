using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;
    [SerializeField] private Transform _goPoint;
    
    private NavMeshAgent agent;
    void Start()
    {
        _currentHp = _maxHp;
        agent = GetComponent<NavMeshAgent>();
        
        if(GameMap.PositionMainObject != null)
            _goPoint = GameMap.PositionMainObject;
    }

    void Update()
    {
        agent.SetDestination(_goPoint.position);
    }
}
