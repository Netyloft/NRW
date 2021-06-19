using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private bool isVisib;

    private IEnumerator Spawn()
    {
        while (true)
        {
            var timeSpread = Random.Range(-1.5f, 1.5f);
            yield return new WaitForSeconds(2 + timeSpread);
            
            if(WaveController.counter.IsPossibleSpawnEnemy() && !isVisib && Vector3.Distance(transform.position, GameMap.PositionMainObject.position) > 8f)
                Instantiate(_enemy, transform.position, Quaternion.identity);
        }
    }

    private void StartSpawn() => StartCoroutine(Spawn());
    
    private void OnEnable()
    {
        WaveController.StartWave += StartSpawn;
    }

    private void OnDisable()
    {
        WaveController.StartWave -= StartSpawn;
    }

    private void OnBecameVisible()
    {
        isVisib = true;
    }

    private void OnBecameInvisible()
    {
        isVisib = false;
        StartCoroutine(Spawn());
    }
}