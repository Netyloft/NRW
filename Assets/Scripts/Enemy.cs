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
    
    public delegate void OnChangedState();

    public static event OnChangedState WasBorn;
    public static event OnChangedState WasDie;
    
    private NavMeshAgent agent;
    void Start()
    {
        _currentHp = _maxHp;
        agent = GetComponent<NavMeshAgent>();
        
        WasBorn?.Invoke();
        if(GameMap.PositionMainObject != null)
            _goPoint = GameMap.PositionMainObject;
    }

    void Update()
    {
        agent.SetDestination(_goPoint.position);
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        
        if(_currentHp <= 0)
            Die();
    }

    private void Die()
    {
        WasDie?.Invoke();
        Destroy(gameObject);
    }
}
