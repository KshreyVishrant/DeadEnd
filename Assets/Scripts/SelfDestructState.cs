using UnityEngine;

public class SelfDestructState : IEnemyState
{
    private bool hasPlayedDeath = false;

    public void EnterState(EnemyAIController enemy)
    {
        enemy.agent.isStopped = true;
        enemy.agent.ResetPath();

        if (!hasPlayedDeath)
        {
            hasPlayedDeath = true;

            if (enemy.animationComponent != null && enemy.animationComponent.GetClip("death1") != null)
            {
                enemy.animationComponent.Play("death1");
                Debug.Log("Monster self-destructed. Player wins!");
            }
        }
    }

    public void UpdateState(EnemyAIController enemy)
    {
        // Do nothing – permanently in this state
    }

    public void ExitState(EnemyAIController enemy)
    {
        // Never expected to exit
    }
}
