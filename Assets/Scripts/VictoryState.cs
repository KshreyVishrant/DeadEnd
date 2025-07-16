using UnityEngine;

public class VictoryState : IEnemyState
{
    public void EnterState(EnemyAIController enemy)
    {
        enemy.agent.isStopped = true;
        enemy.agent.ResetPath();

        Debug.Log("Monster wins! Entered VictoryState.");

        if (enemy.animationComponent != null)
        {
            // Replace "victory1" with whatever animation clip you want to use
            if (enemy.animationComponent.GetClip("rage") != null)
                enemy.animationComponent.Play("rage");
        }
    }

    public void UpdateState(EnemyAIController enemy)
    {
        // Stay in this state forever, do nothing
    }

    public void ExitState(EnemyAIController enemy)
    {
        // Not expected to exit
    }
}
