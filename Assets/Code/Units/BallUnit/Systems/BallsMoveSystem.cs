using Code.Units.BallUnit.Components;
using Code.Units.Base;
using Code.Units.Base.Components;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.BallUnit.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BallsMoveSystem))]
    public sealed class BallsMoveSystem : FixedUpdateSystem
    {
        private Filter _filterBalls;

        public override void OnAwake()
        {    
            _filterBalls = World.Filter.With<Unit>().With<Ball>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filterBalls)
            {
                ref var unit = ref entity.GetComponent<Unit>();
                ref var ball = ref entity.GetComponent<Ball>();
                unit.rigidbody.AddForce(ball.force * deltaTime, ForceMode.Force);
            }
        }

        public override void Dispose()
        {
            _filterBalls = null;
        }
    }
}