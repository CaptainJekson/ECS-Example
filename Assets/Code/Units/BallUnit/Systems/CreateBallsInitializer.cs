using Code.Units.BallUnit.Components;
using Code.Units.BallUnit.EventComponents;
using Code.Units.Base.Components;
using Code.Units.Base.Providers;
using Code.Units.Utility;
using DG.Tweening;
using Morpeh;
using UnityEngine;

namespace Code.Units.BallUnit.Systems
{
    public sealed class CreateBallsInitializer : IInitializer
    {
        private Filter _filterSpawners;
        private Filter _filterBalls;
        private CollisionPool _collisionPool;
        
        public World World { get; set; }

        public CreateBallsInitializer(CollisionPool collisionPool)
        {
            _collisionPool = collisionPool;
        }

        public void OnAwake()
        {
            _filterSpawners = World.Filter.With<Spawner>();
            _filterBalls = World.Filter.With<Unit>().With<Ball>();

            foreach (var entity in _filterSpawners)
            {
                ref var spawner = ref entity.GetComponent<Spawner>();
                var sequence = DOTween.Sequence();

                for (var i = 0; i < spawner.countRed; i++)
                {
                    var tempSpawner = spawner;
                    sequence.AppendCallback(() => { CreateBall(tempSpawner, BallType.Red); });
                    sequence.AppendInterval(0.1f);
                }

                for (var i = 0; i < spawner.countGreen; i++)
                {
                    var tempSpawner = spawner;
                    sequence.AppendCallback(() => { CreateBall(tempSpawner, BallType.Green); });
                    sequence.AppendInterval(0.1f);
                }

                sequence.AppendCallback(AddForceBalls);
            }
        }

        public void Dispose()
        {
            _filterSpawners = null;
            _filterBalls = null;
        }

        private void CreateBall(Spawner spawner, BallType ballType)
        {
            var randomPosition = GetRandomPosition();

            while (Physics.CheckSphere(randomPosition, 0.5f))
            {
                randomPosition = GetRandomPosition();
            }

            var spawnedEnemy = Object.Instantiate(spawner.ball, randomPosition, Quaternion.identity);
            spawnedEnemy.GetComponent<CollidableObjectProvider>().Init(_collisionPool);
            ref var ballComponent = ref spawnedEnemy.Entity.GetComponent<Ball>();
            ballComponent.ballType = ballType;
            spawnedEnemy.Entity.AddComponent<CreateBallEvent>().ballType = ballType;

            switch (ballType)
            {
                case BallType.Red:
                    ballComponent.meshRenderer.material.color = Color.red;
                    spawnedEnemy.Entity.AddComponent<RedBall>();
                    break;
                case BallType.Green:
                    ballComponent.meshRenderer.material.color = Color.green;
                    spawnedEnemy.Entity.AddComponent<BlueBall>();
                    break;
            }
        }

        private Vector3 GetRandomPosition()
        {
            var randomPosition = new Vector3(Random.Range(-4.0f, 10.0f), 2.7f, Random.Range(9.0f, -8.0f));
            return randomPosition;
        }

        private void AddForceBalls()
        {
            foreach (var entity in _filterBalls)
            {
                ref var unit = ref entity.GetComponent<Unit>();
                ref var ball = ref entity.GetComponent<Ball>();
                var randomForce =
                    new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)) * unit.speed;
                ball.force = randomForce;
            }
        }
    }
}