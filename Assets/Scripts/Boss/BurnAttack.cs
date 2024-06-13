using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnAttack : MonoBehaviour
{
    [SerializeField] private DataBoss _data;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Transform player;
    [SerializeField] private float attackDistance;
    [SerializeField] private Animator _animator;


    public void Update()
    {
        Vector3 directionPlayer = player.position - transform.position;
        float distance = directionPlayer.magnitude;
        if (distance <= attackDistance && directionPlayer.x < 0 && _data.CanAttack)
        {
            StartCoroutine(Attack());
        }
    }


    public IEnumerator Attack()
    {
        _data.CanAttack = false;

        _animator.SetBool("Attack",true);

        yield return new WaitForSeconds(1f);

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _data.AttackRadius, _data.enemyLayers);

        foreach (Collider player in hitEnemiesR)
        {
            player.GetComponent<Player>().TakeDamage(_data.BurnDamage);

        }
        
        _animator.SetBool("Attack",false);
        yield return new WaitForSeconds(5f);

        _data.CanAttack = true;
    }
    
    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, _data.AttackRadius);

    }
}