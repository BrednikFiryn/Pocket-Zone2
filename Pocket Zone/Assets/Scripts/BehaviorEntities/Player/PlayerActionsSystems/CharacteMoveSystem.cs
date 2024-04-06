using DefaultNamespace;
using Unity.Entities;
using UnityEngine;

public class CharacterMoveSystem : ComponentSystem
{
    private EntityQuery moveQuery;

    protected override void OnCreate()
    {
        moveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(),
            ComponentType.ReadOnly<Transform>(), ComponentType.ReadOnly<UserInputData>());
    }

    protected override void OnUpdate()
    {
        Entities.With(moveQuery).ForEach(
        (Entity entity, ref InputData inputData, UserInputData input, Transform transform) =>
        {
              if (input.moveAction != null && input.moveAction is moveAbility ability)
            {
                Vector2 direction = new Vector2(inputData.move.x, inputData.move.y);
                inputData.Speed = input.speed / 5;

                if (direction.sqrMagnitude < 0.1f) return;
                ref var speed = ref inputData.Speed;
                transform.position += (Vector3)direction * speed * Time.DeltaTime;
                float scaleX = (direction.x > 0) ? 0.7f : -0.7f;
                Vector2 newScale = new Vector2(scaleX, transform.localScale.y);
                transform.localScale = newScale;
            }
        });
    }
}