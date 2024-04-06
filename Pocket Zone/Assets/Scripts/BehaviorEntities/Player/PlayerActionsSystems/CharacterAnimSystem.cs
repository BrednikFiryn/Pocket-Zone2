using DefaultNamespace;
using Unity.Entities;
using UnityEngine;

public class CharacterAnimDeathSystem : ComponentSystem
{
    private EntityQuery moveQuery;

    protected override void OnCreate()
    {
        moveQuery = GetEntityQuery(ComponentType.ReadOnly<AnimData>(), ComponentType.ReadOnly<Animator>());
    }

    protected override void OnUpdate()
    {
        Entities.With(moveQuery).ForEach(
          (Entity entity, ref InputData move, UserInputData inputData, Animator animator) =>
          {
              Vector3 direction = new Vector3(move.move.x, 0, move.move.y);

              if (inputData.moveAction is moveAbility ability)
              {
                  if (inputData.moveAction != null)
                  {
                      animator.SetBool(inputData.moveAnimHash, direction.sqrMagnitude > 0.1f);

                      if (inputData.moveAnimHash == string.Empty) return;
                  } 
              }
          });
    }
}