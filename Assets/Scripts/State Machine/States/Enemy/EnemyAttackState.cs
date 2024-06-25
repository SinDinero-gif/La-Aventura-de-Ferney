using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttackState : BaseState
{
    float attackCoolDown = 0;

    public override void EnterState(EnemyStateMachine enemy)
    {
        enemy._data.CanAttack = true;
        Attack(enemy);
    }

    public override void UpdateState(EnemyStateMachine enemy)
    {
        attackCoolDown += Time.deltaTime;

        if (attackCoolDown <= enemy._data.AttackSpeed)
        {
            enemy._data.CanAttack = false;
        }
        else
        {
            enemy._data.CanAttack = true;
        }

        float distanceToPlayer = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);

        if (distanceToPlayer <= 1f && enemy._data.CanAttack)
        {
            Attack(enemy);
        }
        else if (distanceToPlayer > enemy._data.AttackRange && !enemy._data.CanAttack)
        { 
            enemy.SwitchState(enemy.chaseState);
        }
    }

    public override void ExitState(EnemyStateMachine enemy)
    {
        Debug.Log(enemy._data.Name + " Deja de atacar");
    }

    public void Attack(EnemyStateMachine enemy)
    {

        Debug.Log(enemy._data.Name + " ataca a Ferney!");
        enemy._data.CanAttack = false;

        enemy.animator.SetTrigger("Attack");

        if (enemy.enemyType == EnemyType.Rata)
        {
            AudioManager.Instance.PlayEnemySFX("Rata Attack");

        }
        else if (enemy.enemyType == EnemyType.Kukaracha)
        {
            AudioManager.Instance.PlayEnemySFX("Kukaracha Attack");
        }


        Collider[] hitEnemiesR = Physics.OverlapSphere(enemy.attackPoint.position, enemy._data.AttackRange, enemy._data.enemyLayers);

        foreach (Collider player in hitEnemiesR)
        {
            player.GetComponent<Player>().TakeDamage(enemy._data.Damage - 5);
            AudioManager.Instance.PlayPlayerSFX("Player Hurt");
            Debug.Log(enemy._data.Name + " ha atacado a Ferney!, haciendo " + enemy._data.Damage + " de da�o");
        }

        enemy._data.CanAttack = true;

    }
}
