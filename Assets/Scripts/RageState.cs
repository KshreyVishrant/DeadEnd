// =====================================
// RageState.cs
// =====================================
using UnityEngine;

public class RageState : IEnemyState
{
    public void EnterState(EnemyAIController enemy)
    {
        enemy.isRaging = true;
        enemy.attackDamage = 30;
        enemy.agent.speed = 7.5f;
        enemy.animationComponent.Play("run1");
        Debug.Log("Entered RageState");
    }

    public void UpdateState(EnemyAIController enemy)
    {
        enemy.agent.SetDestination(enemy.player.position);

        Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);
        }


        if (enemy.GetTimer() >= enemy.timeToActivate && enemy.IsPlayerInRange())
        {
            enemy.SetState(new AttackState());
        }
    }

    public void ExitState(EnemyAIController enemy) { }
}

