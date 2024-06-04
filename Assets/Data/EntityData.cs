using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "DataBlocks/Entities", order = 1)]
public class EntityData : ScriptableObject
{
    [SerializeField]
    private int _id;

    [SerializeField]
    private string _name;

    [SerializeField]
    private int _punchDamage;

    [SerializeField] 
    private int _kickDamage;

    [SerializeField]
    private float _attackRadius;

    [SerializeField]
    private bool _canAttack;

    [SerializeField] 
    private int _maxHealth;

    [SerializeField]
    private int _currentHealth;

    public int Id
    {
        get => _id;
        set => _id = value;
        
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int PunchDamage
    {
        get => _punchDamage;
        set
        {   
            if (_punchDamage > 50) { _punchDamage = 50; }
            else _punchDamage = value;
        }
    }

    public int KickDamage
    {
        get => _punchDamage;
        set
        {
            if (_punchDamage > 80) { _punchDamage = 80; }
            else _punchDamage = value;
        }
    }

    public float AttackRadius
    {
        get => _attackRadius;
        set {  _attackRadius = value; }
    }

    public LayerMask enemyLayers;

    public bool CanAttack
    {
        get => _canAttack;
        set { _canAttack = value; }
    }

    public int MaxHealth
    {
        get => _maxHealth;
        set { _maxHealth = value; }
    }

    public int CurrentHealth
    {
        get => _currentHealth;
        set { _currentHealth = value; }
    }
}
