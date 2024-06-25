using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : BaseState
{
    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy.navMeshAgent.isStopped = true;
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);

        enemy.animator.SetFloat("Distace", distanceToPlayer);

        if (distanceToPlayer <= enemy._data.ChaseRange)
        {
            enemy.SwitchState(enemy.chaseState);
        }
        else
        {
            enemy.navMeshAgent.isStopped = true;
        }
    }

    public override void ExitState(EnemyStateMachine enemy)
    {
        Debug.Log("Deja de estar Idle");
        enemy.navMeshAgent.isStopped = false;
    }
}
