using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private string _deathAnimHash;
    [SerializeField] private SettingsPlayer settingsPlayer;
    private GameObject _healthBar;
    private PlayerStats _playerStats;
    private Image _healthCount;
    private Animator _animDeath;
    private IDeath _deathController;
    public float _health;

    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _animDeath = GetComponent<Animator>();
        _deathController = FindObjectOfType<GameOver>();
        HealthStatus();
        HealthCheck();
    }

    private void HealthStatus()
    {
        _healthBar = GameObject.FindGameObjectWithTag("Health");
        _healthCount = _healthBar.GetComponent<Image>();
    }

    public void HealthCheck()
    {
        _health = settingsPlayer.health;
        _healthCount.fillAmount = _health;

        if (_health <= 0)
        {
            _health = 0;
            _animDeath.SetBool(_deathAnimHash, true);
            _playerStats.EntityDestroy();
            gameObject.GetComponent<Collider2D>().enabled = false;
            _deathController.GameOverControll();
        }
        else if (_health > 1) _health = 1;
    }
}




