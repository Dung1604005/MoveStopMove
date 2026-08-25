using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private Enemy enemyPrefab;

    [SerializeField] private IndicatorUI indicatorUIPrefab;

    [SerializeField] private List<Enemy> listEnemy = new List<Enemy>();

    [SerializeField] private int maxEnemy;

    [SerializeField] private float maxRangeSpawn;

    [SerializeField] private float minRangeSpawn;

    public void OnInit()
    {
        ClearAllEnemy();
        for(int i = 0 ; i < maxEnemy; i++)
        {
            GenerateEnemy();
        }
    }

    public void GenerateEnemy()
    {
        if(!CanSpawnEnemy()) return;
        Vector3 playerPos = LevelManager.Instance.GetPlayerPosition();
        
        if(LevelManager.Instance.GetMapManager().GetRandomNavMeshPoint(playerPos, minRangeSpawn, maxRangeSpawn,out Vector3 spawnPos))
        {
            Enemy enemy = SimplePool.Spawn(enemyPrefab, spawnPos, Quaternion.identity);
            IndicatorUI indicatorUI = SimplePool.Spawn(indicatorUIPrefab, Vector3.zero, Quaternion.identity);
            int randomLevel = Math.Max(1, UnityEngine.Random.Range(LevelManager.Instance.GetPlayerLevel() - 1, LevelManager.Instance.GetPlayerLevel() + 2));
            enemy.GetCombat().SetWeapon(DataManager.Instance.WeaponDatabase.GetRandomWeaponPrefab());
            enemy.OnInit();
            enemy.GetStat().JumpToLevel(randomLevel);
            enemy.SetIndicator(indicatorUI);
            indicatorUI.SetInfor(enemy.GetStat().Level, enemy.GetVisual().ColorType, enemy.TF);
            indicatorUI.OnInit();
            listEnemy.Add(enemy);
        }
    }

    public Enemy GetRandomEnemy(Enemy excludeEnemy = null)
    {
        int randomEnemy = UnityEngine.Random.Range(0, listEnemy.Count);
        if(listEnemy[randomEnemy] == excludeEnemy)
        {
            randomEnemy = (randomEnemy + 1) % listEnemy.Count;
        }
        return listEnemy[randomEnemy];
    }

    public bool CanSpawnEnemy()
    {
        return LevelManager.Instance.CurrentAlive >= listEnemy.Count + 1 && listEnemy.Count + 1 <= maxEnemy;
    }

    public void DeSpawnEnemy(Enemy enemy)
    {
        listEnemy.Remove(enemy);
        enemy.GetIndicator().OnDespawn();
        enemy.OnDespawn();
        LevelManager.Instance.SetCurrentAlive(LevelManager.Instance.CurrentAlive - 1);
    }

    public void ClearAllEnemy()
    {
        for(int i= listEnemy.Count - 1; i >= 0; i--)
        {
            listEnemy[i].OnDespawn();
        }
        listEnemy.Clear();
    }
}
