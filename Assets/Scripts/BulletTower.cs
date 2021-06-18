using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : MonoBehaviour
{
    public float Damage = 35f;
    public int Speed = 10;
    public TargetPoint Target;
    
    void Update()
    {
        if (Target)
        { 
            transform.position = Vector3.MoveTowards(transform.position, Target.Position, Time.deltaTime * Speed);
        }
        
        if (!Target)    
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Target.Enemy.TakeDamage(Damage);
        Destroy(gameObject);
    }
}
