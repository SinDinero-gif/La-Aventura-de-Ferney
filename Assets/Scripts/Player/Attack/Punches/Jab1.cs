using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jab1 : MonoBehaviour, IAttack
{
    public EntityData _entityData;

    [SerializeField] Transform attackPoint;

    [SerializeField] Animator _playerAnimator;

    private int attackCounter;

    public static int staticAttackCounter;

    private void Start()
    {
        attackCounter = 0;
        _entityData.CanAttack = true;
    }

    private void Update()
    {
        StartCoroutine(Attack());
        
        attackCounter = staticAttackCounter;
    }

    public IEnumerator Attack()
    {
        if (Input.GetKeyDown(KeyCode.E) && _entityData.CanAttack)
        {
            attackCounter = 1;
            _entityData.CanAttack = false;
            _playerAnimator.SetTrigger("Attack1");

            yield return new WaitForSeconds(0.23f);

            Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _entityData.AttackRadius, _entityData.enemyLayers);

            foreach (Collider enemy in hitEnemiesR)
            {

                enemy.GetComponent<Enemy>().TakeDamage(_entityData.PunchDamage);
                Debug.Log("The " + enemy.name + " was hit, dealing " + _entityData.PunchDamage + " of Damage.");
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                _entityData.CanAttack = true;
            }

        }else if (Input.GetKeyDown(KeyCode.E) && attackCounter == 1 && _entityData.CanAttack)
        {
            
            _playerAnimator.SetTrigger("Attack2");

            yield return new WaitForSeconds(0.23f);

            Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _entityData.AttackRadius, _entityData.enemyLayers);

            foreach (Collider enemy in hitEnemiesR)
            {

                enemy.GetComponent<Enemy>().TakeDamage(_entityData.PunchDamage);
                Debug.Log("The " + enemy.name + " was hit, dealing " + _entityData.PunchDamage + " of Damage.");
            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                attackCounter = 2;
                _entityData.CanAttack = false;
            }
        }
        else
        {
            attackCounter = 2;
            _entityData.CanAttack = false;
        }

        yield return new WaitForSeconds(0.30f);

        _entityData.CanAttack = true;

        attackCounter = 0;




    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, _entityData.AttackRadius);
        
    }

}
