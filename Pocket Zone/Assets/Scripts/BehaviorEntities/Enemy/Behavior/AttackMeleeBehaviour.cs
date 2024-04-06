using UnityEngine;

public class AttackMeleeBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float attackTime;
    private ApplyDamagePlayer _applyDamagePlayer;
    private PlayerStats _playerStats;
    private HealthPlayer _healthBar;


    private float _attackTimeMin = float.MinValue;

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _applyDamagePlayer = GetComponent<ApplyDamagePlayer>();
        _healthBar = FindObjectOfType<HealthPlayer>();
    }

    public float Evaluate()
    {
        return 1 / (this.gameObject.transform.position - _healthBar.transform.position).magnitude;
    }

    public void Behave()
    {
        if (Time.time < _attackTimeMin + attackTime) return;

        if (_applyDamagePlayer.attack)
        {  
            AttackMelee();
        }

        else return;
    }

    private void AttackMelee()
    {
        _healthBar.HealthCheck();
        _playerStats.Damage(damage);
        _attackTimeMin = Time.time;
    }


}
