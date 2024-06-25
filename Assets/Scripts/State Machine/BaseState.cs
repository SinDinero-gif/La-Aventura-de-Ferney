
using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(EnemyStateMachine enemy);

    public abstract void UpdateState(EnemyStateMachine enemy);

    public abstract void ExitState(EnemyStateMachine enemy);
}
