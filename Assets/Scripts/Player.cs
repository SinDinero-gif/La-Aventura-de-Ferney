using System;
using Attack;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Punch Attack1;
    public Kick Attack2;
    public HondaVital AttackSpecial;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Attack1.Attack();
        if (Input.GetKeyDown(KeyCode.S))
            Attack2.Attack();
        if (Input.GetKeyDown(KeyCode.D))
            AttackSpecial.Attack();
    }
}
