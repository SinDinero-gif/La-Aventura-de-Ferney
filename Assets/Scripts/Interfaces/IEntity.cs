using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    

    public virtual void TakeDamage(int damage)
    {

    }

    public virtual void Die() { }
}
