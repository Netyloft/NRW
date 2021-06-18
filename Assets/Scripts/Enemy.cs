using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxHp;
    [SerializeField] private float _currentHp;
    [SerializeField] private Transform _goPoint;

    [SerializeField] private HealthBar _healthBar;

    public delegate void OnChangedState();

    public static event OnChangedState WasBorn;
    public static event OnChangedState WasDie;

    private Vector3 oldPosition;

    private NavMeshAgent agent;

    void Start()
    {
        _currentHp = _maxHp;
        _healthBar.SetMaxHealth(_maxHp);
        agent = GetComponent<NavMeshAgent>();
        oldPosition = transform.position;

        WasBorn?.Invoke();
        if (GameMap.PositionMainObject != null)
            _goPoint = GameMap.PositionMainObject;

        agent.SetDestination(_goPoint.position);

        StartCoroutine(Chek());
    }

    private void FixedUpdate()
    {
        transform.LookAt(GameMap.PositionMainObject);
    }

    private IEnumerator Chek()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (Vector3.Distance(oldPosition, transform.position) < 1f)
                DestroyObstacle();
            
            oldPosition = transform.position;
        }
    }
    
    void DestroyObstacle()
    {
        var rayForward = new Ray(transform.position, transform.forward * 2f);
        var rayRight = new Ray(transform.position, Quaternion.AngleAxis(45, Vector3.up) * transform.forward * 2f);
        var rayLeft = new Ray(transform.position, Quaternion.AngleAxis(-45, Vector3.up) * transform.forward * 2f);
        Debug.DrawRay(rayForward.origin, rayForward.direction * 2f);
        Debug.DrawRay(rayRight.origin, rayRight.direction * 2f);
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * 2f);
        RaycastHit hit;
        
        if (Physics.Raycast(rayForward, out hit) || Physics.Raycast(rayLeft, out hit) || Physics.Raycast(rayRight, out hit))
        {
            var h = hit.transform.gameObject;
            var g = h.GetComponent<MapObject>();

            if (g != null && hit.distance <= 1.1f)
            {
                g.TakeDamage(10000);
                return;
            }
        }
        
        if (Physics.Raycast(rayLeft, out hit))
        {
            var h = hit.transform.gameObject;
            var g = h.GetComponent<MapObject>();

            if (g != null && hit.distance <= 1.5f)
            {
                g.TakeDamage(10000);
                return;
            }
        }
        
        if (Physics.Raycast(rayRight, out hit))
        {
            var h = hit.transform.gameObject;
            var g = h.GetComponent<MapObject>();

            if (g != null && hit.distance <= 1.5f)
            {
                g.TakeDamage(10000);
                return;
            }
                
        }
    }
    
    public void TakeDamage(float damage)
    {
        _currentHp -= damage;
        _healthBar.SetHealth(_currentHp);

        if (_currentHp <= 0)
            Die();
    }

    private void Die()
    {
        WasDie?.Invoke();
        Destroy(gameObject);
    }
}