using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jab : MonoBehaviour, IAttack
{
    
    private int attackDamage = 10;

    private bool canAttack = true;

    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private float attackRange;
    public LayerMask enemyLayers;

    [SerializeField]
    private Animator _playerAnimator;
     

    private void Update()
    {      

        if (Input.GetKeyDown(KeyCode.E) && canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        canAttack = false;
        _playerAnimator.SetTrigger("Attack1"); 

        yield return new WaitForSeconds(0.23f);

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);        
        
        foreach (Collider enemy in hitEnemiesR)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            Debug.Log("The " + enemy.name + " was hit, dealing " + attackDamage + " of Damage.");
        }

        yield return new WaitForSeconds(0.17f);
        
        canAttack = true;
       
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
        
        
        
    }

}
