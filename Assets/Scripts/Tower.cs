using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private const int ENEMY_LAYER_MASK = 1 << 6;

    public string Type;
    public float SpeedFire = 10;
    [Range(1.5f, 10.5f)] public float range = 5.0f;
    public GameObject Bullet;
    public Transform StartBulletPos;
    //public Transform LookAtTarget;
    public Transform Target;
    public bool isShoot;

    private TargetPoint _target;

    private void Update()
    {
        if (!Target) return;
        
        //LookAtTarget.transform.LookAt(Target);
        if (!isShoot && Vector3.Distance(Target.position, transform.position) <= range)
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

    private IEnumerator Fire()
    {
        isShoot = true;
        yield return new WaitForSeconds(SpeedFire);
        var bullet = Instantiate(Bullet, StartBulletPos.position, Quaternion.identity);
        bullet.GetComponent<BulletTower>().Target = Target;
        isShoot = false;
    }
    
}
