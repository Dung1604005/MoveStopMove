using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private EnemyState enemyState;

    [SerializeField] private Vector3 destination;

    public override void OnInit()
    {
        base.OnInit();
        SetActiveAgent(true);
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        SetActiveAgent(false);
    }

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
        if (IsAgentActive())
        {
            this.destination = _destination;
            agent.SetDestination(destination);
        }

    }

    public bool IsAgentActive()
    {
        return !stat.IsDead && agent.enabled;
    }

    public override bool IsStop()
    {
        return (tf.position - destination).sqrMagnitude < 1f;
    }

    public override void Move()
    {

    }

    public override void StopMove()
    {
        SetDestination(tf.position);
    }

    public void SetActiveAgent(bool active)
    {
        agent.enabled = active;
    }


}
