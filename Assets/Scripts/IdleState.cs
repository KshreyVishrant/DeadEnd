// =====================================
// IdleState.cs
// =====================================
using UnityEngine;

public class IdleState : IEnemyState
{
    public void EnterState(EnemyAIController enemy)
    {
        enemy.agent.isStopped = true;
        enemy.animationComponent.Play("idle1");
        Debug.Log("Entered IdleState");
    }

    public void UpdateState(EnemyAIController enemy) { }

    public void ExitState(EnemyAIController enemy)
    {
        enemy.agent.isStopped = false;
    }
}