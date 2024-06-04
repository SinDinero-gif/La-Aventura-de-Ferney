using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jab : MonoBehaviour, IAttack
{
    public EntityData _entityData;

    [SerializeField] Transform attackPoint;

    [SerializeField] Animator _playerAnimator;

    private void Start()
    {
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

        Collider[] hitEnemiesR = Physics.OverlapBox(attackPoint.position, _entityData.AttackArea, Quaternion.identity.normalized, _entityData.enemyLayers);

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
        Gizmos.DrawCube(attackPoint.position, _entityData.AttackArea);
        
        
        
    }

}
