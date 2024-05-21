using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEntity
{
    

    public virtual void TakeDamage(int damage)
    {

    }

    public virtual void Die() { }
}
