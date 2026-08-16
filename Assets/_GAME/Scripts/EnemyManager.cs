using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private List<Enemy> listEnemy = new List<Enemy>();


    public void OnInit()
    {
        listEnemy = new List<Enemy>();
    }

    public Enemy GetRandomEnemy()
    {
        int randomEnemy = Random.Range(0, listEnemy.Count);

        return listEnemy[randomEnemy];
    }
}
