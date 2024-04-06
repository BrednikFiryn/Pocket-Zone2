using DefaultNamespace;
using UnityEngine;
using Zenject;

public class ShootAbility : MonoBehaviour, IAbility
{
    [SerializeField] private GameObject[] bullet;
    [SerializeField] private GameObject player;
    [SerializeField] private int index = 0;
    [SerializeField] private float shootDelay;
    [SerializeField] private float overheating;
    [SerializeField] private float bulletSpeed;
    private float shootTime = float.MinValue;
    private float _shootDelayConst;

    private void Start()
    {
        _shootDelayConst = shootDelay;
    }

    [Inject]
    public void Construct(BindBullet bindBullet)
    {
        bullet = bindBullet.bullets;
    }

    public void Execute()
    {
        if (Time.time < shootTime + shootDelay) return;

        shootDelay = _shootDelayConst;
        shootTime = Time.time;

        if (bullet != null)
        {
            Shooting();

            if (index < bullet.Length) ++index;
            if (index == bullet.Length)
            {
                index = 0;
                shootDelay = overheating;
            }
        }
    }

    private void Shooting()
    {
        bullet[index].SetActive(true);
        var _transform = this.transform;
        bullet[index].transform.position = _transform.position;
        Rigidbody2D rb = bullet[index].GetComponent<Rigidbody2D>();

        if (player.transform.localScale.x < 0) rb.velocity = Vector2.right * -bulletSpeed;
        else rb.velocity = Vector2.right * bulletSpeed;
    }
}