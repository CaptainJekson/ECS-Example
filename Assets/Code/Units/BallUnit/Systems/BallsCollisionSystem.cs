using Code.Units.BallUnit.Components;
using Code.Units.BallUnit.Providers;
using Code.Units.Base.Components;
using Morpeh;
using UnityEngine;

namespace Code.Units.BallUnit.Systems
{
    public sealed class BallsCollisionSystem : ISystem
    {
        private Filter _filter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<CollisionInfo>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var collisionInfo = ref entity.GetComponent<CollisionInfo>();
                var other = collisionInfo.otherCollision;
                var current = collisionInfo.currentEntity;
                var normal = new Vector3(other.contacts[0].normal.x, 0.0f, other.contacts[0].normal.z);

                ref var currentBallComponent = ref current.GetComponent<Ball>();
                ref var currentUnitComponent = ref current.GetComponent<Unit>();

                var otherBall = other.gameObject.GetComponent<BallProvider>();
                if (otherBall)
                {
                    ref var otherBallComponent = ref otherBall.Entity.GetComponent<Ball>();

                    if (otherBallComponent.ballType != currentBallComponent.ballType)
                    {
                        Reduce(currentUnitComponent.transform, otherBall);
                        return;
                    }
                }
                
                currentBallComponent.force = Vector3.Reflect(currentBallComponent.force, normal);
            }
        }
        
        public void Dispose()
        {
            _filter = null;
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
    }
}