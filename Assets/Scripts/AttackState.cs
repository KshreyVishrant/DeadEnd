using UnityEngine;

public class AttackState : IEnemyState
{
    private bool isAttacking = false;
    private float attackDuration = 2.5f; // Duration of the "attack1" animation
    private float attackTimer = 0f;

    public void EnterState(EnemyAIController enemy)
    {
        enemy.agent.isStopped = true;
        enemy.agent.ResetPath();
        isAttacking = false;
        attackTimer = 0f;

        Debug.Log("Entered AttackState");
    }

    public void UpdateState(EnemyAIController enemy)
    {
        // Get player status reference
        PlayerStatus playerStatus = enemy.player.GetComponent<PlayerStatus>();

        // Stop attacking and enter victory if player is dead
        if (playerStatus != null && !playerStatus.isAlive())
        {
            Debug.Log("Player is dead. Switching to VictoryState.");
            enemy.SetState(new VictoryState());
            return;
        }

        // Face the player
        Vector3 direction = (enemy.player.position - enemy.transform.position).normalized;
        direction.y = 0f;
        if (direction != Vector3.zero)
        {
            enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10f);
        }

        // Return to chase if player is out of range
        if (!enemy.IsPlayerInRange())
        {
            Debug.Log("Player out of range, returning to chase");
            enemy.SetState(enemy.isRaging ? new RageState() : new HuntingState());
            return;
        }

        // Attack logic (only one attack per animation duration)
        if (!isAttacking && enemy.GetTimer() >= enemy.timeToActivate)
        {
            Debug.Log("Attacking player");
            enemy.animationComponent.Stop();
            enemy.animationComponent.Play("attack1");

            if (playerStatus != null)
            {
                playerStatus.ApplyDamage(enemy.attackDamage);
                Debug.Log($"Player hit for {enemy.attackDamage} HP!");
            }

            isAttacking = true;
            attackTimer = attackDuration;
        }

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                isAttacking = false; // Ready to attack again
            }
        }
    }

    public void ExitState(EnemyAIController enemy)
    {
        enemy.agent.isStopped = false;
        Debug.Log("Exiting AttackState");
    }
}
