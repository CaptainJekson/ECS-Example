using Code.Units.BallUnit.Components;
using Code.Units.BallUnit.EventComponents;
using Code.Units.Base;
using DG.Tweening;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Units.BallUnit.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(CreateBallsInitializer))]
    public sealed class CreateBallsInitializer : Initializer
    {
        private Filter _filterSpawners;
        private Filter _filterBalls;

        public override void OnAwake()
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
                    sequence.AppendCallback(() =>
                    {
                        CreateBall(tempSpawner, BallType.Red);
                    });
                    sequence.AppendInterval(0.1f);   
                }
                
                for (var i = 0; i < spawner.countRed; i++)
                {
                    var tempSpawner = spawner;
                    sequence.AppendCallback(() =>
                    {
                        CreateBall(tempSpawner, BallType.Green);
                    });
                    sequence.AppendInterval(0.1f);   
                }
                
                sequence.AppendCallback(AddForceBalls);
            }
        }

        private void CreateBall(Spawner spawner, BallType ballType)
        {
            var randomPosition = GetRandomPosition();

            while(Physics.CheckSphere(randomPosition, 0.5f))
            {
                randomPosition = GetRandomPosition();
            }

            var spawnedEnemy = Instantiate(spawner.ball, randomPosition, Quaternion.identity);
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