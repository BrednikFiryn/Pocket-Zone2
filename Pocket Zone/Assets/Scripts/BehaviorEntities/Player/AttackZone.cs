using UnityEngine;

public class AttackZone : MonoBehaviour
{
    [SerializeField] private Color colorRest;
    [SerializeField] private Color colorAttack;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            IAttack.attack = true;
            gameObject.GetComponent<Renderer>().material.color = colorAttack;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            IAttack.attack = false;
            gameObject.GetComponent<Renderer>().material.color = colorRest;
        }
    }
}