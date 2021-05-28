using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : MonoBehaviour
{
    public int Damage = 25;
    public int Speed = 10;
    public TargetPoint Target;

    
    void Update()
    {
        if (Target)
            transform.position = Vector3.MoveTowards(transform.position, Target.Position, Time.deltaTime * Speed);
        if (!Target)    
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
