using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jab : MonoBehaviour, IAttack
{
    
    public int attackDamage = 10;

    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private float attackRange;
    public LayerMask enemyLayers;

    [SerializeField]
    private Animator _playerAnimator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }
    }

    public void Attack()
    {
        _playerAnimator.SetTrigger("Attack1"); 


        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);


        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("The " + enemy.name + " was hit, dealing " + attackDamage + " of Damage.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, attackRange);

        
    }

}
