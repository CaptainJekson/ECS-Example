using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Ball.Systems
{
    public class BallCollisionSystem : ReactiveSystem<GameEntity>
    {
        public BallCollisionSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ReflectBallEvent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasReflectBallEvent;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var ball = entity.ballComponents;
                var reflectBallEvent = entity.reflectBallEvent;
                ball.force = Vector3.Reflect(ball.force, reflectBallEvent.normal);
                entity.RemoveReflectBallEvent(); 
            }
        }
    }
}