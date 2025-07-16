// =====================================
// IEnemyState.cs
// =====================================
public interface IEnemyState
{
    void EnterState(EnemyAIController enemy);
    void UpdateState(EnemyAIController enemy);
    void ExitState(EnemyAIController enemy);
}