using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public static EnemyCounter counter;
    
    [SerializeField] private int waveCount;
    [SerializeField] private int enemyOnWave;
    [SerializeField] private int spawnedEnemy;
    [SerializeField] private int aliveEnemy;
    private void Awake()
    {
        counter = this;
    }

    public bool IsPossibleSpawnEnemy()
    {
        return enemyOnWave <= spawnedEnemy;
    }

    private void ReduceEnemies()
    {
        aliveEnemy--;
        
        if(aliveEnemy == 0 && spawnedEnemy >= enemyOnWave)
            NextWave();
    }
    
    private void AddEnemies()
    {
        spawnedEnemy++;
        aliveEnemy++;
    }

    private void NextWave()
    {
        
    }

    private void OnEnable()
    {
        Enemy.WasBorn += AddEnemies;
        Enemy.WasDie += ReduceEnemies;
    }

    private void OnDisable()
    {
        Enemy.WasBorn -= AddEnemies;
        Enemy.WasDie -= ReduceEnemies;
    }
}
