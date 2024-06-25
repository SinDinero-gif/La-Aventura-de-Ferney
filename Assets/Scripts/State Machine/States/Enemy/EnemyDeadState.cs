using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : BaseState
{
    float destroyCount = 0;

    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy.animator.SetTrigger("Die");
        enemy.navMeshAgent.isStopped = true;
        Debug.Log("Enemy is dead");
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
        destroyCount += Time.deltaTime;

        if (destroyCount >= 4f)
        {
            UnityEngine.Object.Destroy(enemy.gameObject);
        }
    }

    public override void ExitState(EnemyStateMachine enemy)
    {
        
    }
}
