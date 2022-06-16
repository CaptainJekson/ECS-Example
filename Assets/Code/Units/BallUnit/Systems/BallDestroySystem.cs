using Code.Units.BallUnit.Components;
using Code.Units.BallUnit.EventComponents;
using Code.Units.Base;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.BallUnit.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(BallDestroySystem))]
    public sealed class BallDestroySystem : UpdateSystem
    {
        private Filter _filter;
        
        public override void OnAwake()
        {
            _filter = World.Filter.With<Unit>().With<Ball>();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var unit = ref entity.GetComponent<Unit>();
                ref var ball = ref entity.GetComponent<Ball>();

                if (unit.transform.position.y < -5.0f || unit.transform.localScale.x < 0.2f)
                {
                    entity.AddComponent<DestroyBallEvent>().ballType = ball.ballType;
                    Destroy(unit.transform.gameObject);
                }
            }
        }
    }
}