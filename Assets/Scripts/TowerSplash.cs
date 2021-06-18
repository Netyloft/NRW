using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSplash : Building
{
    private const int ENEMY_LAYER_MASK = 1 << 9;
    private TargetPoint _target;
    [SerializeField, Range(1f, 40f)] private float _damagePerSecond = 10f;
    [SerializeField] private Transform _turret;
    [SerializeField] private Transform _laser;
    [SerializeField] private float range = 5f;
    private Vector3 _laserScale;


    protected override void OnBuilt()
    {
        
    }

    private bool IsTargetExists()
    {
        Collider[] targets = Physics.OverlapSphere(transform.localPosition, range, ENEMY_LAYER_MASK);
        if (targets.Length > 0)
        {
            _target = targets[0].GetComponent<TargetPoint>();
            return true;
        }
        _target = null;
        return false;
    }

    private bool IsTargetTracked()
    {
        if (_target == null)
            return false;
        Vector3 selfPosition = transform.localPosition;
        Vector3 targetPosition = _target.Position;
        if (Vector3.Distance(selfPosition, targetPosition) > range + _target.ColliderSize)
        {
            _target = null;
            return false;
        }
        return true;
    }

    private void Awake()
    {
        _laserScale = _laser.localScale;
    }
    private void Shoot()
    {
        var t = _target.Position;
        _turret.LookAt(t);
        _laser.localRotation = _turret.localRotation;

        var distanceToTarget = Vector3.Distance(_turret.position, t);
        _laserScale.z = distanceToTarget;
        _laser.localScale = _laserScale;
        _laser.localPosition = _turret.localPosition + 0.5f * distanceToTarget * _laser.forward;

        _target.Enemy.TakeDamage(_damagePerSecond * Time.deltaTime);
    }

    void Update()
    {
        if (IsTargetTracked() || IsTargetExists())
        {
            Shoot();
        }
        else
            _laser.localScale = Vector3.zero;
    }
}
