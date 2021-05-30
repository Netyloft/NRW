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

    private Vector3 oldPosition;

    private NavMeshAgent agent;

    void Start()
    {
        _currentHp = _maxHp;
        agent = GetComponent<NavMeshAgent>();
        oldPosition = transform.position;

        WasBorn?.Invoke();
        if (GameMap.PositionMainObject != null)
            _goPoint = GameMap.PositionMainObject;

        agent.SetDestination(_goPoint.position);

        StartCoroutine(Chek());
    }
    
    private IEnumerator Chek()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (oldPosition == transform.position)
                DestroyObstacle();
            
            oldPosition = transform.position;
        }
    }
    
    void DestroyObstacle()
    {
        var ray = new Ray(transform.position, transform.forward * 2f);
        Debug.DrawRay(ray.origin, ray.direction * 2f);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            var h = hit.transform.gameObject;
            var g = h.GetComponent<MapObject>();
            
            if(g != null)
                g.TakeDamage(10000);
        }
    }
    
    public void TakeDamage(int damage)
    {
        _currentHp -= damage;

        if (_currentHp <= 0)
            Die();
    }

    private void Die()
    {
        WasDie?.Invoke();
        Destroy(gameObject);
    }
}