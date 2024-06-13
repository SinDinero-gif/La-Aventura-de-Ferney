using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpit : MonoBehaviour, IAttack
{
    [SerializeField] private GameObject bornPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private Transform pointSpit;
    [SerializeField] private float attackRange;
    [SerializeField] Animator _animator;
    private bool isAttacking = false;
    private Coroutine spitCoroutine;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        //StartCoroutine(SpitAttack());
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > attackRange && !isAttacking)
        {
            StartSpitAttack();
        }
        else if (isAttacking)
        {
            StopSpitAttack();
        }
    }

    public void StartSpitAttack()
    {
        if (!isAttacking)
        {
            _animator.SetBool("Vomito",true);
            spitCoroutine = StartCoroutine(SpitAttack());
        }
    }

    public void StopSpitAttack()
    {
        if (spitCoroutine != null)
        {
            StopCoroutine(spitCoroutine);
            spitCoroutine = null;
            _animator.SetBool("Vomito",false);
            isAttacking = false;
        }
    }


    public void InstanciateSpit()
    {
        GameObject spit = Instantiate(bornPrefab, pointSpit.position, Quaternion.identity);
        Rigidbody rb = spit.GetComponent<Rigidbody>();
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Spit spitA = spit.AddComponent<Spit>();
        spitA.damage = 10; 
        rb.AddForce(direction * 1000);
    }
    public IEnumerator SpitAttack()
    {
        yield return new WaitForSeconds(4.6f);
        _animator.SetBool("Vomito",false);
        isAttacking = false;
    }

}
