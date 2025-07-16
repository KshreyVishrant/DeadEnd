// =====================================
// HuntingState.cs
// =====================================
using UnityEngine;

public class HuntingState : IEnemyState
{
    public void EnterState(EnemyAIController enemy)
    {
        enemy.agent.speed = 2.5f;
        enemy.animationComponent.Play("walk2");
        Debug.Log("Entered HuntingState");
    }

    public void UpdateState(EnemyAIController enemy)
    {
        enemy.agent.SetDestination(enemy.player.position);

        if (enemy.GetTimer() >= enemy.timeToActivate && enemy.IsPlayerInRange())
        {
            enemy.SetState(new AttackState());
        }
    }

    public void ExitState(EnemyAIController enemy) { }
}