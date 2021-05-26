using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public string Type;
    public float SpeedFire = 10;
    public float range = 5;
    public GameObject Bullet;
    public Transform StartBulletPos;
    //public Transform LookAtTarget;
    public Transform Target;
    public bool isShoot;

    private void Update()
    {
        if (!Target) return;
        
        //LookAtTarget.transform.LookAt(Target);
        if (!isShoot && Vector3.Distance(Target.position, transform.position) <= range)
            StartCoroutine(Fire());
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
