using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private const int ENEMY_LAYER_MASK = 1 << 9;

    public string Type;
    public float SpeedFire = 10;
    [Range(1.5f, 10.5f)] public float range = 5.0f;
    public GameObject Bullet;
    public Transform StartBulletPos;
    //public Transform LookAtTarget;
    //public Transform Target;
    public bool isShoot;

    private TargetPoint _target;

    private void Update()
    {
        if (!isShoot && (IsTargetExists() || IsTargetTracked()))
            StartCoroutine(Fire());
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

    private IEnumerator Fire()
    {
        isShoot = true;
        yield return new WaitForSeconds(SpeedFire);
        var bullet = Instantiate(Bullet, StartBulletPos.position, Quaternion.identity);
        bullet.GetComponent<BulletTower>().Target = _target;
        isShoot = false;
    }
    
}
