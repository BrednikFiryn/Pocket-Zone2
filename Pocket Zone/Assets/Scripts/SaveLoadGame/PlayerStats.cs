using System.IO;
using Unity.Entities;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private SettingsPlayer settingsWarrior;
    [SerializeField] private MoveAbility player;
    private float _healthHero;
    private float _xPosHero;
    private float _yPosHero;

    private void Start()
    {
        player = FindObjectOfType<MoveAbility>();
    }

    public void LoadPlayerData()
    {
        string filePath = Application.persistentDataPath + "/PocketZone_data.json";
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(jsonData))
            {
                PlayerData playerData = JsonUtility.FromJson<PlayerData>(jsonData);
                settingsWarrior.health = playerData.health;
                settingsWarrior.startPoint.position = new Vector3(playerData.Xpos, playerData.Ypos, 0);
            }
            else
            {
                Debug.LogError("Ошибка загрузки данных: JSON-строка пуста или недопустима.");
            }
        }
        else
        {
            Debug.LogError("Ошибка загрузки данных: файл не найден.");
        }
    }

    public void SavePlayerData()
    {
        string filePath = Application.persistentDataPath + "/PocketZone_data.json";
        PlayerData playerData = new PlayerData(_healthHero, _xPosHero, _yPosHero);
        _healthHero = settingsWarrior.health;
        _xPosHero = player.gameObject.transform.position.x;
        _yPosHero = player.gameObject.transform.position.y;

        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonData);
    }

    public void SaveDefaultData()
    {
        string filePath = Application.persistentDataPath + "/PocketZone_data.json";
        PlayerData playerData = new PlayerData(_healthHero, _xPosHero, _yPosHero);
        _healthHero = settingsWarrior.defHealth;
        _xPosHero = settingsWarrior.defXpos;
        _yPosHero = settingsWarrior.defYpos;

        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonData);
    }

    public void Damage(float damage)
    {
        settingsWarrior.health -= damage;

        if (damage >= settingsWarrior.health)
        {
            settingsWarrior.health = 0;
        }
        else return;
    }

    public void Healing(float health)
    {
        settingsWarrior.health += health;
    }

    public void EntityDestroy()
    {
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        entityManager.DestroyEntity(entityManager.UniversalQuery);
    }
}

[System.Serializable]
public class PlayerData
{
    public float health;
    public float Xpos;
    public float Ypos;
    public PlayerData(float health, float Xpos, float Ypos)
    {
        this.health = health;
        this.Xpos = Xpos;
        this.Ypos = Ypos;
    }
}