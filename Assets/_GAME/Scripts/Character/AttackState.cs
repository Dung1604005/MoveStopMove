using UnityEngine;

public static class AttackState
{
      public static void OnEnter(Enemy e)
    {
        e.ChangeAnim(GameConfig.ANIM_ATTACK);
        e.GetCombat().Attack();

    }

    public static void OnExecute(Enemy e)
    {
        
    }

    public static void OnExit(Enemy e)
    {
        
    }
}
