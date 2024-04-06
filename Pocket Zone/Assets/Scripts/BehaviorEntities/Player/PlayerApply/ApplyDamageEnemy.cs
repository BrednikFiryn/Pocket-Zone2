using UnityEngine;

public class ApplyDamageEnemy : MonoBehaviour
{
    [SerializeField] private SettingsPlayer settingsPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<HealthEnemy>().Damage(settingsPlayer.damage);
            gameObject.SetActive(false);
            gameObject.transform.position = new Vector3(0, 0, 0);
        }
    }
}
