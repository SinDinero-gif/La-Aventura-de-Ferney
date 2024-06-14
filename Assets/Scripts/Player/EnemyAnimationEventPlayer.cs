using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventPlayer : MonoBehaviour
{
    public EnemyType enemyType;

    public void Step1()
    {
        if (enemyType == EnemyType.Rat)
        {
            AudioManager.Instance.PlayEnemySFX("Rata Step1");

        }
        else if (enemyType == EnemyType.Kukaracha)
        {
            AudioManager.Instance.PlayEnemySFX("Kukaracha Step1");
        }
    }

    public void Step2()
    {
        if (enemyType == EnemyType.Rat)
        {
            AudioManager.Instance.PlayEnemySFX("Rata Step2");

        }
        else if (enemyType == EnemyType.Kukaracha)
        {
            AudioManager.Instance.PlayEnemySFX("Kukaracha Step2");
        }
    }
}
