
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private string deathAnimHash;
    [SerializeField] private float healthEnemy;
    [SerializeField] private GameObject healthBar;
    private Image _healthCount;
    private Animator _animDeath;

    public float health
    {
        get => healthEnemy;
        set
        {
            healthEnemy = value;
            _healthCount.fillAmount = healthEnemy;
            if (healthEnemy <= 0)
            {
                 healthEnemy = 0;
                 Destroy(gameObject.GetComponent<NavMeshAgent>());
                _animDeath.SetBool(deathAnimHash, true);

                Collider2D[] colliders = gameObject.GetComponents<Collider2D>();
                foreach (Collider2D collider in colliders)
                {
                    collider.enabled = false;
                }
            }
            else if (healthEnemy > 1) health = 1;
        }
    }

    private void Start()
    {
        _animDeath = GetComponent<Animator>();
        HealthStatus();
    }

    private void HealthStatus()
    {
        _healthCount = healthBar.GetComponent<Image>();
    }

    public void Damage(float damage)
    {
        health -= damage;
    }
}