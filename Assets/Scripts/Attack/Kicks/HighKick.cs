using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighKick : MonoBehaviour,IAttack
{
    //[SerializeField] private float damageKick;
    //private float kickCold = 0f;
    //private float lastKick;


    //private void Start()
    //{
    //     lastKick = -kickCold;
    //}


    //private void Update()
    //{
    //    if (Time.time - lastKick >= kickCold)
    //    {


    //        if (Input.GetKey(KeyCode.R))
    //        {
    //            StartCoroutine(Attack());
    //            lastKick = Time.time;
    //        }
    //    }
    //}

    //public IEnumerator Attack()
    //{
    //    yield return null;
    //    RaycastHit hit;
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    Debug.DrawRay(ray.origin,ray.direction*30,Color.red);


    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(20);
    //    }

    //}

    private int attackDamage = 15;

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

        if (Input.GetKeyDown(KeyCode.R) && canAttack)
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
            Debug.Log("The " + enemy.name + " was kicked, dealing " + attackDamage + " of Damage.");
        }

        yield return new WaitForSeconds(0.17f);

        canAttack = true;

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.gray;
        Gizmos.DrawSphere(attackPoint.position, attackRange);



    }

}
