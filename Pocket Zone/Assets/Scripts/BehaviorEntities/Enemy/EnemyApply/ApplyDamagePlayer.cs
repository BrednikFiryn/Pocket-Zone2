using UnityEngine;

public class ApplyDamagePlayer : MonoBehaviour
{
    [HideInInspector] public bool attack = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            attack = false;
        }
    }
}
