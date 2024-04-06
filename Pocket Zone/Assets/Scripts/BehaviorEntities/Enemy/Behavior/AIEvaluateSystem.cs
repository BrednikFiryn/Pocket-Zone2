using Unity.Entities;

public class AIEvaluateSystem : ComponentSystem
{
    private EntityQuery _evaluateQuery;

    protected override void OnCreate()
    {
        _evaluateQuery = GetEntityQuery(ComponentType.ReadOnly<AIAgent>());
    }

    protected override void OnUpdate()
    {
        Entities.With(_evaluateQuery).ForEach(
        (Entity entity, BehaviourManager manager) =>
        {
            float hightScore = float.MinValue;
            manager.activeBehaviour = null;
            foreach (var behaviour in manager._behaviours)
            {
                if (behaviour is IBehaviour ai)
                {
                    var currentScore = ai.Evaluate();

                    if (currentScore > hightScore)
                    {
                        hightScore = currentScore;
                        manager.activeBehaviour = ai;
                    }
                }
            }
        });
    }
}