using UnityEngine;

public static class IdleState
{
    public static void OnEnter(Enemy e)
    {
        e.ChangeAnim(GameConfig.ANIM_IDLE);
        e.StopMove();

        e.GetEnemyState().SetTimer(1f);
    }

    public static void OnExecute(Enemy e)
    {
        if (e.GetCombat().HaveTarget && e.GetCombat().CanAttack())
        {
            e.ChangeState(EnemyStateType.ATTACKSTATE);
        }
        else
        {
            if(e.GetEnemyState().GetTimer() < 0.01f)
            {
                e.ChangeState(EnemyStateType.PATROLSTATE);
            }
        }

    }

    public static void OnExit(Enemy e)
    {
        
    }
}
