using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "ScriptableObjects/Entities", order = 1)]
public class EntityData : ScriptableObject
{
    public string Id;

    public float attackDamage;

    public float attackRadius;

    public float attackSpeed;

    public LayerMask enemyLayers;

    public bool canAttack;

    private int _maxHealth;

    public int _currentHealth;

    public Animator _animator;

}
