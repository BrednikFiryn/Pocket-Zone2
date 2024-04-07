using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player Settings")]
public class SettingsPlayer : ScriptableObject
{
    // текущие параметры
    public float health;
    public float speed;
    public float damage;
    public Transform startPoint;
    public GameObject hero;

    // начальные параметры
    public float defHealth;
    public float defXpos;
    public float defYpos;
}
