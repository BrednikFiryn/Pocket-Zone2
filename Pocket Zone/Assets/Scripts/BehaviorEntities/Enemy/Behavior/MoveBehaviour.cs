using UnityEngine;
using UnityEngine.AI;

public class MoveBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private string mutantAnimHash;
    [SerializeField] private MoveAbility _enemyTarget;
    private Animator _anim;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _enemyTarget = FindObjectOfType<MoveAbility>();
        _agent.speed = _speed;
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _anim = GetComponent<Animator>();
    }

    public float Evaluate()
    {
        return 0.5f;
    }

    public void Behave()
    {
        if (_agent != null)
        {
            TargetOfEnemyAttack();
        }
        else return;
    }

    public void TargetOfEnemyAttack()
    {
        if (_agent != null && _enemyTarget != null)
        {
            Vector2 targetPosition = new Vector2(_enemyTarget.transform.position.x, _enemyTarget.transform.position.y);
            _agent.SetDestination(targetPosition);

            Vector2 direction = (_enemyTarget.transform.position - transform.position).normalized;
            float scaleX = (direction.x > 0) ? 1 : -1;
            Vector2 newScale = new Vector2(scaleX, transform.localScale.y);
            transform.localScale = newScale;
        }
    }
}
