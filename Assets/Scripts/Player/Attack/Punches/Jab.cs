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
            StartCoroutine(Attack1());
            attackCounter = 0;
            Debug.Log(attackCounter);
        }

    }

    public IEnumerator Attack1()
    {
        _entityData.CanAttack = false;
        _playerAnimator.SetInteger("Punch", attackCounter); 

        yield return new WaitForSeconds(0.23f);

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _entityData.AttackRadius, _entityData.enemyLayers);

        foreach (Collider enemy in hitEnemiesR)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(_entityData.PunchDamage);
            Debug.Log("The " + enemy.name + " was hit, dealing " + _entityData.PunchDamage + " of Damage.");
        }

        yield return new WaitForSeconds(0.17f);

        _entityData.CanAttack = true;
       
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, _entityData.AttackRadius);
        
    }

}
