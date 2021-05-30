using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static WaveController counter;
    
    [Header("Wave Info")]
    [SerializeField] private int waveCount;
    [SerializeField] private int enemyOnWave;
    [SerializeField] private int spawnedEnemy;
    [SerializeField] private int aliveEnemy;
    
    [Space(15f)]
    [SerializeField] private int numberOfAddedEnemies;
    [SerializeField] private float startTimeOfTheFirstWave;

    public delegate void NextWave();
    public static event NextWave StartWave;

    private bool isFirst = true;
    private bool isMainBuildet;
    private void Awake()
    {
        counter = this;
    }

    public bool IsPossibleSpawnEnemy()
    {
        return enemyOnWave >= spawnedEnemy && isMainBuildet;
    }

    private void ReduceEnemies()
    {
        aliveEnemy--;
        
        if(aliveEnemy <= 0 && spawnedEnemy >= enemyOnWave)
            Invoke("StartNextWave", 10f);
    }
    
    private void AddEnemies()
    {
        spawnedEnemy++;
        aliveEnemy++;
    }

    private void StartNextWave()
    {
        if (isFirst) enemyOnWave -= numberOfAddedEnemies;
        
        enemyOnWave += numberOfAddedEnemies;
        spawnedEnemy = 0;
        aliveEnemy = 0;
        waveCount++;
        isFirst = false;
        
        StartWave?.Invoke();
    }

    private void FirstWave()
    {
        Debug.Log("Началась первая волна");
        isMainBuildet = true;
        Invoke("StartNextWave", startTimeOfTheFirstWave);
    }

    private void OnEnable()
    {
        MainObject.MainBuildet += FirstWave;
        Enemy.WasBorn += AddEnemies;
        Enemy.WasDie += ReduceEnemies;
    }

    private void OnDisable()
    {
        MainObject.MainBuildet -= FirstWave;
        Enemy.WasBorn -= AddEnemies;
        Enemy.WasDie -= ReduceEnemies;
    }
}