using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private bool isVisib;

    public IEnumerator Spawn()
    {
        while (WaveController.counter.IsPossibleSpawnEnemy() && !isVisib)
        {
            var timeSpread = Random.Range(-1.5f, 1.5f);
            yield return new WaitForSeconds(2 + timeSpread);
            Instantiate(_enemy, transform.position, Quaternion.identity);
        }
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private void OnEnable()
    {
        WaveController.StartWave += StartSpawn;
    }

    private void OnDisable()
    {
        WaveController.StartWave += StartSpawn;
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