using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player Settings")]
public class SettingsPlayer : ScriptableObject
{
    public float health;
    public float speed;
    public float damage;
    public Transform startPoint;

    public GameObject hero;
}
