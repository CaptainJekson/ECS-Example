using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Ball.Systems
{
    public class BallDestroySystem : ReactiveSystem<GameEntity>
    {
        public BallDestroySystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ReduceBallEvent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasReduceBallEvent;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var ball = entity.ballComponents;

                if (ball.transform.position.y < -5.0f || ball.transform.localScale.x < 0.2f)
                {
                    Debug.Log("Destroy");
                    entity.Destroy();
                    Object.Destroy(ball.transform.gameObject);
                }
            }
        }
    }
}