using Entitas;
using UnityEngine;

namespace Code.Ball.Systems
{
    public class BallsMoveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
    
        public BallsMoveSystem(Contexts contexts)
        {
            _entities = contexts.game.GetGroup(Matcher<GameEntity>.AllOf(GameMatcher.BallComponents));
        }
    
        public void Execute()
        {
            foreach (var entity in _entities)
            {
                var ball = entity.ballComponents;
                ball.rigidbody.AddForce(ball.force * Time.deltaTime, ForceMode.Force);
            }
        }
    }
}