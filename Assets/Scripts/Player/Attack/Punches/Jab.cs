using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jab : MonoBehaviour, IAttack
{
    public EntityData _entityData;

    [SerializeField] Transform attackPoint;

    [SerializeField] Animator _playerAnimator;

    private int attackCounter;

    private void Start()
    {
        attackCounter = 0;
        _entityData.CanAttack = true;
    }

    private void Update()
    {      

        if (Input.GetKeyDown(KeyCode.E) && _entityData.CanAttack && attackCounter < 1)
        {
            StartCoroutine(Attack1());
            attackCounter++;
            Debug.Log(attackCounter);
        }

        if (Input.GetKeyDown(KeyCode.E) && _entityData.CanAttack && attackCounter >= 1)
        {
            StartCoroutine(Attack2());
            attackCounter = 0;
            Debug.Log(attackCounter);
        }

    }

    private IEnumerator Attack2()
    {
        _entityData.CanAttack = false;
        _playerAnimator.SetTrigger("Attack2");

        yield return new WaitForSeconds(0.23f);

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _entityData.AttackRadius, _entityData.enemyLayers);

        foreach (Collider enemy in hitEnemiesR)
        {

            enemy.GetComponent<Enemy>().TakeDamage(_entityData.PunchDamage + 5);
            Debug.Log("The " + enemy.name + " was hit, dealing " + _entityData.PunchDamage + 5 + " of Damage.");
        }

        yield return new WaitForSeconds(0.13f);
    }

    public IEnumerator Attack1()
    {
        
        _playerAnimator.SetTrigger("Attack1"); 

        yield return new WaitForSeconds(0.23f);

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _entityData.AttackRadius, _entityData.enemyLayers);

        foreach (Collider enemy in hitEnemiesR)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(_entityData.PunchDamage);
            Debug.Log("The " + enemy.name + " was hit, dealing " + _entityData.PunchDamage + " of Damage.");
        }

        yield return new WaitForSeconds(0.13f);

        _entityData.CanAttack = true;
       
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, _entityData.AttackRadius);
        
    }

}
