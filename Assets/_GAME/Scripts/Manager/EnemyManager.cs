using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private List<Enemy> listEnemy = new List<Enemy>();


    public void OnInit()
    {
        listEnemy = new List<Enemy>();
    }

    public void GenerateEnemy()
    {
        
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
}
