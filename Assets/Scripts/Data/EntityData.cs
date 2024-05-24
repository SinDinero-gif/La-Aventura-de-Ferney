using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entities", menuName = "ScriptableObjects/Attack", order = 1)]
public class EntityData : ScriptableObject
{
    public string Id;

    public float attackDamage;
}
