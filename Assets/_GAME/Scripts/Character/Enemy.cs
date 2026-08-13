using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private EnemyState enemyState;

    private Vector3 destination;

    public EnemyState GetEnemyState()
    {
        return enemyState;
    }

    public void ChangeState(EnemyStateType enemyStateType)
    {
        enemyState.ChangeState(enemyStateType);
    }

    public void SetDestination(Vector3 _destination)
    {
        this.destination = _destination;
        agent.SetDestination(destination);
    }

    public override bool IsStop()
    {
        return (tf.position - destination).sqrMagnitude < 0.1f;
    }

    public override void Move()
    {
        
    }

    public override void StopMove()
    {
        SetDestination(tf.position);
    }


}
