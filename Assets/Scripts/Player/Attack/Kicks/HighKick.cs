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

    public EntityData _entityData;

    [SerializeField] Transform attackPoint;
    [SerializeField] Animator animator;

    private void Start()
    {
        _entityData.CanAttack = true;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && _entityData.CanAttack)
        {
            StartCoroutine(Attack());
        }
    }

    public IEnumerator Attack()
    {
        _entityData.CanAttack = false;
        animator.SetTrigger("Attack1");

        yield return new WaitForSeconds(0.23f);

        Collider[] hitEnemiesR = Physics.OverlapBox(attackPoint.position, _entityData.AttackArea, Quaternion.identity.normalized, _entityData.enemyLayers);

        foreach (Collider enemy in hitEnemiesR)
        {

            enemy.GetComponent<Enemy>().TakeDamage(_entityData.KickDamage + 5);
            Debug.Log("The " + enemy.name + " was hit, dealing " + _entityData.KickDamage + 5 + " of Damage.");
        }

        yield return new WaitForSeconds(0.17f);

        _entityData.CanAttack = true;

    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackPoint.position, _entityData.AttackArea);



    }

}
