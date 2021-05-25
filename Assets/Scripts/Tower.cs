using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public string Type;
    public float SpeedFire = 10;
    public GameObject Bullet;
    public Transform StartBulletPos;
    public Transform LookAtTarget;
    public Transform Target;
    public bool isShoot;

    
    void Start()
    {
        isShoot = false;
    }

    void Update()
    {
        if (Target)
        {
            LookAtTarget.transform.LookAt(Target);
            if (!isShoot)
                StartCoroutine(Fire());
                
        }
    }

    IEnumerator Fire()
    {
        isShoot = true;
        yield return new WaitForSeconds(SpeedFire);
        GameObject bullet = GameObject.Instantiate(Bullet, StartBulletPos.position, Quaternion.identity) as GameObject;
        bullet.GetComponent<BulletTower>().Target = Target;
        bullet.GetComponent<BulletTower>().tower = this;
        isShoot = false;
    }
    
}
