using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jab1 : MonoBehaviour, IAttack
{
    public EntityData _entityData;

    [SerializeField] Transform attackPoint;

    [SerializeField] Animator _playerAnimator;

    public int attackCounter;

    private void Start()
    {
        int attackCounter = 0;
        _entityData.CanAttack = true;
    }

    private void Update()
    {      

        if (Input.GetKeyDown(KeyCode.E) && _entityData.CanAttack)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        _entityData.CanAttack = false;
        _playerAnimator.SetTrigger("Attack1"); 

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
