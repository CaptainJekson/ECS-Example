using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Ball.Systems
{
    public class BallReduceSystem : ReactiveSystem<GameEntity>
    {
        public BallReduceSystem(Contexts contexts) : base(contexts.game)
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
                var reduceBallEvent = entity.reduceBallEvent;
                Reduce(ball.transform, reduceBallEvent.otherBall);
            }
        }
        
        private void Reduce(Transform currentBall, global::Ball otherBall)
        {
            if(otherBall == null)
                return;
            
            var distance = Vector3.Distance(otherBall.transform.position, currentBall.position);

            var otherRadius = otherBall.transform.localScale.x / 2;
            var currentRadius = currentBall.localScale.x / 2;
            var halfRadius = ((otherRadius + currentRadius) - distance) / 2;
            var newOtherRadius = otherRadius - halfRadius;
            var newCurrentRadius = currentRadius - halfRadius;

            if (newOtherRadius < otherRadius)
            {
                otherBall.transform.localScale = Vector3.one * newOtherRadius;
            }

            if (newCurrentRadius < currentRadius)
            {
                currentBall.localScale = Vector3.one * newCurrentRadius;
            }
        }
    }
}