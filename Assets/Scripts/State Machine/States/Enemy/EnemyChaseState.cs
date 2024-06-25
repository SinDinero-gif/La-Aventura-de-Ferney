using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : BaseState
{
    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy.animator.SetBool("isChasing", true);
        enemy.navMeshAgent.SetDestination(enemy.playerTransform.position);
        
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
        enemy.navMeshAgent.SetDestination(enemy.playerTransform.position);

        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);

        if (distanceToPlayer > enemy._data.ChaseRange) 
        {
            enemy.SwitchState(enemy.idleState);
        }else if (distanceToPlayer <= enemy._data.AttackRange)
        {
            enemy.SwitchState(enemy.attackState);
        }
    }

    public override void ExitState(EnemyStateMachine enemy)
    {
        Debug.Log("Deja de perseguir");
        enemy.animator.SetBool("isChasing", false);
        
    }
}
