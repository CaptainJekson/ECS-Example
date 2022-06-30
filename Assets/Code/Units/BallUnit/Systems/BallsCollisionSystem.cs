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

                if (IsOtherTypeBall(other, current))
                {
                    Reduce(other, current);
                }
                else
                {
                    Reflect(other, current);
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }

        private bool IsOtherTypeBall(Collision other, Entity current)
        {
            var otherBallProvider = other.gameObject.GetComponent<BallProvider>();

            if (otherBallProvider && current.Has<Ball>())
            {
                ref var otherBall = ref otherBallProvider.Entity.GetComponent<Ball>();
                ref var currentBall = ref current.GetComponent<Ball>();

                return otherBall.ballType != currentBall.ballType;
            }

            return false;
        }

        private void Reflect(Collision other, Entity current)
        {
            var normal = new Vector3(other.contacts[0].normal.x, 0.0f, other.contacts[0].normal.z);

            ref var currentBallComponent = ref current.GetComponent<Ball>();
            currentBallComponent.force = Vector3.Reflect(currentBallComponent.force, normal);
        }

        private void Reduce(Collision other, Entity current)
        {
            ref var currentUnit = ref current.GetComponent<Unit>();
            
            var otherBall = other.gameObject.GetComponent<BallProvider>();
            var currentBallTransform = currentUnit.transform;
            
            if (otherBall == null)
                return;

            var distance = Vector3.Distance(otherBall.transform.position, currentBallTransform.position);

            var otherRadius = otherBall.transform.localScale.x / 2;
            var currentRadius = currentBallTransform.localScale.x / 2;
            var halfRadius = ((otherRadius + currentRadius) - distance) / 2;
            var newOtherRadius = otherRadius - halfRadius;
            var newCurrentRadius = currentRadius - halfRadius;

            if (newOtherRadius < otherRadius)
            {
                otherBall.transform.localScale = Vector3.one * newOtherRadius;
            }

            if (newCurrentRadius < currentRadius)
            {
                currentBallTransform.localScale = Vector3.one * newCurrentRadius;
            }
        }
    }
}