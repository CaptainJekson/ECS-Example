using Code.Units.BallUnit.Components;
using Code.Units.BallUnit.EventComponents;
using Code.Units.Base.Components;
using Morpeh;
using UnityEngine;

namespace Code.Units.BallUnit.Systems
{
    public sealed class BallDestroySystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<Unit>().With<Ball>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var unit = ref entity.GetComponent<Unit>();
                ref var ball = ref entity.GetComponent<Ball>();

                if (unit.transform.position.y < -5.0f || unit.transform.localScale.x < 0.2f)
                {
                    entity.AddComponent<DestroyBallEvent>().ballType = ball.ballType;
                    Object.Destroy(unit.transform.gameObject);
                }
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}