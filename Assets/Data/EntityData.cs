using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "DataBlocks/Entities", order = 1)]
public class EntityData : ScriptableObject
{

    [SerializeField]
    private string _name;

    [SerializeField]
    private float _maxHealth;

    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private int _damage;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private bool _canAttack;

    [SerializeField]
    private float _chaseRange;

    [SerializeField]
    private float _attackRange;

    [SerializeField]
    private float _attackSpeed;



    public LayerMask enemyLayers;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }


    public float MaxHealth
    {
        get => _maxHealth;
        set { _maxHealth = value; }
    }

    public float CurrentHealth
    {
        get => _currentHealth;
        set { _currentHealth = value; }
    }

    public int Damage
    {
        get => _damage;
        set
        {   
            if (_damage > 50) { _damage = 50; }
            else _damage = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    public bool CanAttack
    {
        get => _canAttack;
        set { _canAttack = value; }
    }
    public float ChaseRange
    {
        get => _chaseRange;
        set => _chaseRange = value;
    }

    public float AttackRange
    {
        get => _attackRange;
        set => _attackRange = value;
    }


    public float AttackSpeed
    {
        get => _attackSpeed;
        set => _attackSpeed = value;
    }



}



