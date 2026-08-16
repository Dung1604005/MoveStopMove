using UnityEngine;

public class EnemyState: MonoBehaviour
{
    [SerializeField] private EnemyStateType currentState;
    [SerializeField] private Enemy enemy;

    private float timer = 0f;

    public void OnInit()
    {
        SetTimer(0f);
        ChangeState(EnemyStateType.IDLESTATE);
    }

    public void SetTimer(float _timer)
    {
        timer = _timer;
    }

    public float GetTimer()
    {
        return timer;
    }

    public void ChangeState(EnemyStateType enemyStateType)
    {
        OnExit(currentState);
        this.currentState = enemyStateType;
        OnEnter(currentState);
    }

    public void OnExit(EnemyStateType enemyStateType)
    {
        switch (enemyStateType)
        {
            case EnemyStateType.IDLESTATE: IdleState.OnExit(enemy); break;

            case EnemyStateType.PATROLSTATE: PatrolState.OnExit(enemy);break;

            case EnemyStateType.ATTACKSTATE: AttackState.OnExit(enemy); break;
        }
    }
    public void OnEnter(EnemyStateType enemyStateType)
    {
        switch (enemyStateType)
        {
            case EnemyStateType.IDLESTATE: IdleState.OnEnter(enemy); break;

            case EnemyStateType.PATROLSTATE: PatrolState.OnEnter(enemy);break;

            case EnemyStateType.ATTACKSTATE: AttackState.OnEnter(enemy); break;
        }
    }
    public void OnExecute(EnemyStateType enemyStateType)
    {
        switch (enemyStateType)
        {
            case EnemyStateType.IDLESTATE: IdleState.OnExecute(enemy); break;

            case EnemyStateType.PATROLSTATE: PatrolState.OnExecute(enemy);break;

            case EnemyStateType.ATTACKSTATE: AttackState.OnExecute(enemy); break;
        }
    }

    void Update()
    {
        if(timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        OnExecute(currentState);
    }
}


public enum EnemyStateType
{
    IDLESTATE = 0,
    PATROLSTATE = 1,
    ATTACKSTATE = 2
}
