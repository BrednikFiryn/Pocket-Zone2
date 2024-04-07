using UnityEngine;

public class AttackMeleeBehaviour : MonoBehaviour, IBehaviour
{
    private HealthPlayer _healthBar;

    private void Start()
    {
        _healthBar = FindObjectOfType<HealthPlayer>();
    }

    public float Evaluate()
    {
        return (this.gameObject.transform.position - _healthBar.transform.position).magnitude;
    }

    public void Behave()
    {
       
    }
}
