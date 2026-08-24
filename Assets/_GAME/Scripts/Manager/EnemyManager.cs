using System.Collections.Generic;

using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
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
            
            Enemy enemy = SimplePool.Spawn<Enemy>(PoolType.CharacterPool, spawnPos, Quaternion.identity);
            IndicatorUI indicatorUI = SimplePool.Spawn<IndicatorUI>(PoolType.Indicator, Vector3.zero, Quaternion.identity);

            enemy.SetIndicator(indicatorUI);
            indicatorUI.OnInit();
            indicatorUI.SetTarget(enemy.TF);
            listEnemy.Add(enemy);
        }
        
    }

    public Enemy GetRandomEnemy(Enemy excludeEnemy = null)
    {
        int randomEnemy = Random.Range(0, listEnemy.Count);
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
