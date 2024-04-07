using UnityEngine;
using UnityEngine.AI;

public class MoveBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float attackTime;
    [SerializeField] private MoveAbility enemyTarget;
    [SerializeField] float zoneAgression;
    [SerializeField] private ApplyDamagePlayer _applyDamagePlayer;
    private HealthPlayer _healthPlayer;
    private PlayerStats _playerStats;
    private NavMeshAgent _agent;

    private float _attackTimeMin = float.MinValue;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        enemyTarget = FindObjectOfType<MoveAbility>();
        _playerStats = FindObjectOfType<PlayerStats>();
        _healthPlayer = FindObjectOfType<HealthPlayer>();
        _agent.speed = speed;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    public float Evaluate()
    {
        return zoneAgression;
    }

    public void Behave()
    {
        if (_agent != null)
        {
            TargetOfEnemyAttack();

            if (Time.time < _attackTimeMin + attackTime) return;

            if (_applyDamagePlayer.attack)
            {
                AttackMelee();
            }
        }

        else return;
    }

    public void TargetOfEnemyAttack()
    {
        if (_agent != null && enemyTarget != null)
        {
            Vector2 targetPosition = new Vector2(enemyTarget.transform.position.x, enemyTarget.transform.position.y);
            _agent.SetDestination(targetPosition);

            Vector2 direction = (enemyTarget.transform.position - transform.position).normalized;
            float scaleX = (direction.x > 0) ? 1 : -1;
            Vector2 newScale = new Vector2(scaleX, transform.localScale.y);
            transform.localScale = newScale;
        }
    }

    private void AttackMelee()
    {
        _playerStats.Damage(damage);
        _healthPlayer.HealthCheck();
        _attackTimeMin = Time.time;
    }
}
