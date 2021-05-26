using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : MonoBehaviour
{
    //[SerializeField] private int Damage = 25;
    [SerializeField] private int Speed = 10;
    public Transform Target;

    
    void Update()
    {
        if (Target)
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Time.deltaTime * Speed);
        if (!Target)    
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
