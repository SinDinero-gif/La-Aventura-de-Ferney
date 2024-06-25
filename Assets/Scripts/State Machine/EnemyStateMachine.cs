using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    Rata,
    Kukaracha
}

public class EnemyStateMachine : MonoBehaviour
{
    [Header("Data")]
    public EntityData _data;

    [Header("AI")]
    public Transform playerTransform;
    public Transform attackPoint;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    public Animator animator;

    public EnemyType enemyType;

    BaseState currentState;

    public EnemyIdleState idleState = new EnemyIdleState();
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyDamagedState damagedState = new EnemyDamagedState();
    public EnemyDeadState deadState = new EnemyDeadState();

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        _data.CurrentHealth = _data.MaxHealth;

        navMeshAgent.updateRotation = false;
    }

    private void Start()
    {
        currentState = idleState;

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState newState)
    {   
        currentState.ExitState(this);

        currentState = newState;

        currentState.EnterState(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(attackPoint.position, _data.AttackRange);
        Gizmos.color = Color.magenta;
    }
}
