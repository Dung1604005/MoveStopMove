using UnityEngine;

public static class PatrolState
{
    public static void OnEnter(Enemy e)
    {
        e.ChangeAnim(GameConfig.ANIM_MOVING);

        //Random way to move

        int randomWay = Random.Range(0, 3);
        //Cach 1: Di nhat booster gan nhat

        if(randomWay == 1)
        {
            e.SetDestination(MapManager.Instance.BoosterManager.GetNearestBooster(e.TF.position).TF.position);
        }
        //Cach 2: di chuyen den player
        else if(randomWay == 2)
        {
            e.SetDestination(MapManager.Instance.GetPlayerPosition());
        }

        //Cach 3: di chuyen den bot khac
        else
        {
            e.SetDestination(EnemyManager.Instance.GetRandomEnemy().TF.position);
        }


        
    }

    public static void OnExecute(Enemy e)
    {
        if (e.IsStop())
        {
            e.ChangeState(EnemyStateType.PATROLSTATE);
        }
        else if (e.GetCombat().HaveTarget && e.GetCombat().CanAttack())
        {
            e.ChangeState(EnemyStateType.IDLESTATE);
        }
    }

    public static void OnExit(Enemy e)
    {
        
    }

}
