using DefaultNamespace;
using Unity.Entities;

public class CharacterShootSystem : ComponentSystem
{
    private EntityQuery shootQuery;
    protected override void OnCreate()
    {
        shootQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
        ComponentType.ReadOnly<ShootData>(), ComponentType.ReadOnly<UserInputData>());
    }
    protected override void OnUpdate()
    {
        Entities.With(shootQuery).ForEach(
          (Entity entity, UserInputData input, ref ShootData shootData) =>
          {
              if (input.shootAction != null && input.shootAction is IAbility ability)
              {
                  if (shootData.shoot > 0f)
                  {
                      ability.Execute();
                  }
              }
          });
    }
}

