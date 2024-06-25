using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Jab : MonoBehaviour, IAttack
{
    public EntityData _playerData;

    [SerializeField] Transform attackPoint;

    [SerializeField] Animator _playerAnimator;
    
    
    

    [HideInInspector]
    public int attackCounter;

    [SerializeField]
    private float _attackRadius;

    private void Awake()
    {
        
    }

    private void Start()
    {
        attackCounter = 0;
        _playerData.CanAttack = true;
        
    }

    private void Update()
    {      

    }

    public void AttackInput()
    {
        if(attackCounter < 1)
        {
            StartCoroutine(Attack1());
            
            Debug.Log(attackCounter);
        }
        else if(attackCounter >= 1) 
        {
            StartCoroutine(Attack2());
            
            Debug.Log(attackCounter);
        }
        
    }

    public void SpecialInput()
    {
        StartCoroutine(Special());
    }

    private IEnumerator Special()
    {
        _playerData.CanAttack = false;
        _playerAnimator.SetTrigger("SpecialAttack");
        

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _attackRadius, _playerData.enemyLayers);

        foreach (Collider enemy in hitEnemiesR)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            FinalBoss bossComponent = enemy.GetComponent<FinalBoss>();

            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(_playerData.Damage + 10);
                Debug.Log("The " + enemy.name + " was hit, dealing " + (_playerData.Damage + 10) + " of Damage.");
            }
            else if (bossComponent != null)
            {
                bossComponent.TakeDamage(_playerData.Damage + 10);
                Debug.Log("The " + enemy.name + " was hit, dealing " + (_playerData.Damage + 10) + " of Damage.");
            }

        }

        yield return new WaitForSeconds(0.35f);

        attackCounter = 0;
        _playerData.CanAttack = true;

    }

    private IEnumerator Attack2()
    {
        _playerData.CanAttack = false;
        _playerAnimator.SetTrigger("Attack2");
        AudioManager.Instance.PlayPlayerSFX("Player Punch");

        PlayerMovement.Instance.canMove = false;

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _attackRadius, _playerData.enemyLayers);

        foreach (Collider enemy in hitEnemiesR)
        {
            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            FinalBoss bossComponent = enemy.GetComponent<FinalBoss>();

            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(_playerData.Damage + 10);
                Debug.Log("The " + enemy.name + " was hit, dealing " + (_playerData.Damage + 10) + " of Damage.");
            }
            else if (bossComponent != null)
            {
                bossComponent.TakeDamage(_playerData.Damage + 10);
                Debug.Log("The " + enemy.name + " was hit, dealing " + (_playerData.Damage + 10) + " of Damage.");
            }

        }

        yield return new WaitForSeconds(0.35f);

        attackCounter = 0;
        _playerData.CanAttack = true;
    }

    public IEnumerator Attack1()
    {
        attackCounter++;
        _playerAnimator.SetTrigger("Attack1");
        AudioManager.Instance.PlayPlayerSFX("Player Punch");

        PlayerMovement.Instance.canMove = false;

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _attackRadius, _playerData.enemyLayers);

        foreach (Collider enemy in hitEnemiesR)
        {

            Enemy enemyComponent = enemy.GetComponent<Enemy>();
            FinalBoss bossComponent = enemy.GetComponent<FinalBoss>();

            if (enemyComponent != null)
            {
                enemyComponent.TakeDamage(_playerData.Damage + 10);
                Debug.Log("The " + enemy.name + " was hit, dealing " + (_playerData.Damage + 10) + " of Damage.");
            }
            else if (bossComponent != null)
            {
                bossComponent.TakeDamage(_playerData.Damage + 10);
                Debug.Log("The " + enemy.name + " was hit, dealing " + (_playerData.Damage + 10) + " of Damage.");
            }

            
            enemy.GetComponent<Enemy>().TakeDamage(_playerData.Damage + 10);
            Debug.Log("The " + enemy.name + " was hit, dealing " + _playerData.Damage + " of Damage.");

        }

        yield return new WaitForSeconds(0.8f);
    
        _playerData.CanAttack = true;

        yield return new WaitForSeconds(0.2f);

        attackCounter = 0;
    }



    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, _attackRadius);
        
    }

}
