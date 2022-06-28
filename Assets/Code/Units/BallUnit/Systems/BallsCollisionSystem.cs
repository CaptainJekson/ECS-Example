using Code.Units.BallUnit.Components;
using Code.Units.BallUnit.EventComponents;
using Code.Units.BallUnit.Providers;
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
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BallsCollisionSystem))]
    public sealed class BallsCollisionSystem : UpdateSystem
    {
        private Filter _filterReflectBall;
        private Filter _filterReduceBall;
        
        public override void OnAwake()
        {
            _filterReflectBall = World.Filter.With<Unit>().With<Ball>().With<ReflectBallEvent>();
            _filterReduceBall = World.Filter.With<Unit>().With<Ball>().With<ReduceBallEvent>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filterReflectBall)
            {
                ref var ball = ref entity.GetComponent<Ball>();
                ref var reflectBallEvent = ref entity.GetComponent<ReflectBallEvent>();
                ball.force = Vector3.Reflect(ball.force, reflectBallEvent.normal);
                entity.RemoveComponent<ReflectBallEvent>();
            }

            foreach (var entity in _filterReduceBall)
            {
                ref var unit = ref entity.GetComponent<Unit>();
                ref var reduceBallEvent = ref entity.GetComponent<ReduceBallEvent>();
                Reduce(unit.transform, reduceBallEvent.otherBall);
            }
        }
        
        private void Reduce(Transform currentBall, BallProvider otherBall)
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

        public override void Dispose()
        {
            _filterReflectBall = null;
            _filterReduceBall = null;
        }
    }
}