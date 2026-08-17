using UnityEngine;

public static class AttackState
{
      public static void OnEnter(Enemy e)
    {
        
        e.StopMove();
        e.GetCombat().Attack();

    }

    public static void OnExecute(Enemy e)
    {
        if (!e.GetCombat().IsAttacking())
        {
            int randomChoice = Random.Range(0, 3);
            if(randomChoice == 0)
            {
                e.ChangeState(EnemyStateType.IDLESTATE);
            }
            else
            {
                e.ChangeState(EnemyStateType.PATROLSTATE);
            }
            
        }
    }

    public static void OnExit(Enemy e)
    {
        
    }
}
