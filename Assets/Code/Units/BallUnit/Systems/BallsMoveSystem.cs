using Code.Units.BallUnit.Components;
using Code.Units.Base;
using Code.Units.Base.Components;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.BallUnit.Systems
{
    public sealed class BallsMoveSystem : IFixedSystem
    {
        private Filter _filterBalls;
        
        public World World { get; set; }

        public void OnAwake()
        {    
            _filterBalls = World.Filter.With<Unit>().With<Ball>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filterBalls)
            {
                ref var unit = ref entity.GetComponent<Unit>();
                ref var ball = ref entity.GetComponent<Ball>();
                unit.rigidbody.AddForce(ball.force * deltaTime, ForceMode.Force);
            }
        }

        public void Dispose()
        {
            _filterBalls = null;
        }
    }
}