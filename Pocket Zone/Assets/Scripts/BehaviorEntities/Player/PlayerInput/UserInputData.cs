using DefaultNamespace;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class UserInputData : MonoBehaviour, IConvertGameObjectToEntity
{
    [SerializeField] private SettingsPlayer settingsPlayer;
    public float speed;
    public string moveAnimHash;
    public MonoBehaviour shootAction;
    public MonoBehaviour moveAction;

    private void Start()
    {
        speed = settingsPlayer.speed;
    }

    public void Convert(Entity entity, EntityManager dstManager,
        GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new InputData());

        if (shootAction != null && shootAction is IAbility)
        {
            dstManager.AddComponentData(entity, new ShootData());
        }

        if (moveAnimHash != string.Empty)
        {
            dstManager.AddComponentData(entity, new AnimData());
        }
    }
}

public struct InputData : IComponentData
{
    public float Speed;
    public float2 move;
    public float2 rotation;
}

public struct ShootData : IComponentData
{
    public float shoot;
}

public struct AnimData : IComponentData
{

}