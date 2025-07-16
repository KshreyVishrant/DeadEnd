using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Animation animationComponent;

    public float attackRange = 5.5f;
    public float timeToActivate = 60f;
    public float timeToRage = 120f;
    public float gameDuration = 180f;

    public int attackDamage = 10;

    private float timer = 0f;
    private IEnemyState currentState;
    private bool hasSelfDestructed = false;

    [HideInInspector] public bool isRaging = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animationComponent = GetComponent<Animation>();
        agent.stoppingDistance = 5f; // make sure it stops before touching the player

        SetState(new IdleState());
    }

    private void Update()
    {
        // 🛑 Lock FSM if in SelfDestruct or Victory state
        if (currentState is SelfDestructState || currentState is VictoryState)
            return;

        timer += Time.deltaTime;

        // ✅ Trigger self-destruction after game time ends
        if (timer >= gameDuration && !hasSelfDestructed)
        {
            SetState(new SelfDestructState());
            hasSelfDestructed = true;
            return; // prevent other transitions this frame
        }

        // FSM transitions
        if (timer >= timeToRage && !(currentState is RageState || currentState is AttackState))
        {
            SetState(new RageState());
        }
        else if (timer >= timeToActivate && !(currentState is HuntingState || currentState is AttackState || currentState is RageState))
        {
            SetState(new HuntingState());
        }

        // Current state logic
        currentState.UpdateState(this);
    }

    public void SetState(IEnemyState newState)
    {
        currentState?.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
        Debug.Log("Switched to state: " + newState.GetType().Name);
    }

    public bool IsPlayerInRange()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= attackRange;
    }

    public float GetTimer()
    {
        return timer;
    }
}
