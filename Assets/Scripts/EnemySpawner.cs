using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private bool isVisib;
    public IEnumerator Spawn()
    {
        while (!isVisib)
        {
            Instantiate(_enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
        }
        
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private void OnEnable()
    {
        MainObject.OnStart += StartSpawn;
    }

    private void OnDisable()
    {
        MainObject.OnStart -= StartSpawn;
    }

    private void OnBecameVisible()
    {
        Debug.Log("Видно");
        isVisib = true;
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Не видно");
        isVisib = false;
        StartCoroutine(Spawn());
        
        //enabled = true;
    }
}
