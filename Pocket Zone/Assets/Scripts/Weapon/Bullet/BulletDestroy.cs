using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] private string collisionTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == collisionTag)
        {
            BulletDisable();
        }
    }

    private void BulletDisable()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(0, 0, 0);
    }
}
