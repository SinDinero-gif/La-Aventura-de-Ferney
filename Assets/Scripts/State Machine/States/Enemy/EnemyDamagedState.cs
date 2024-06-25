using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedState : BaseState
{


    public override void EnterState(EnemyStateMachine enemy)
    {
        TakeDamage(enemy, enemy.playerData.Damage);
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
       
    }

    public override void ExitState(EnemyStateMachine enemy)
    {
        Debug.Log(enemy._data.Name + " deja de recibir daño");
    }

    private void TakeDamage(EnemyStateMachine enemy,int damage)
    {
        enemy.animator.SetTrigger("Damaged");
        enemy._data.CurrentHealth -= damage;
    }
}
