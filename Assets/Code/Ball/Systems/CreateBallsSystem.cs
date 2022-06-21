using System;
using Code.Ball.Types;
using DG.Tweening;
using Entitas;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.Ball.Systems
{
    public class CreateBallsSystem : IInitializeSystem
    {
        private readonly Contexts _contexts;
        private readonly IGroup<GameEntity> _entities;

        public CreateBallsSystem(Contexts contexts)
        {
            _contexts = contexts;
            _entities = _contexts.game.GetGroup(GameMatcher.BallComponents);
        }
        
        public void Initialize()
        {
            var ballConfig = Resources.Load<BallConfig>("Configs/UnitConfig");
            var sequence = DOTween.Sequence();

            for (var i = 0; i < ballConfig.CountRed; i++)
            {
                CreateBall(sequence, ballConfig, BallType.Red);
            }

            for (var i = 0; i < ballConfig.CountGreen; i++)
            {
                CreateBall(sequence, ballConfig, BallType.Green);
            }

            sequence.AppendCallback(AddForceBalls);
        }

        private void CreateBall(Sequence sequence, BallConfig ballConfig, BallType ballType)
        {
            sequence.AppendCallback(() =>
            {
                var randomPosition = GetRandomPosition();

                while (Physics.CheckSphere(randomPosition, 0.5f))
                {
                    randomPosition = GetRandomPosition();
                }

                var spawnedBall = Object.Instantiate(ballConfig.Ball, randomPosition, Quaternion.identity);
                spawnedBall.GetComponent<MeshRenderer>().material.color = GetColor(ballType);
                var entity = _contexts.game.CreateEntity();
                entity.AddBallComponents(spawnedBall.transform, spawnedBall.GetComponent<Rigidbody>(),
                    spawnedBall.GetComponent<MeshRenderer>(), ballConfig.Speed, ballType, Vector3.zero);
                spawnedBall.Init(entity);
            });
            sequence.AppendInterval(0.1f);
        }
        
        private Vector3 GetRandomPosition()
        {
            var randomPosition = new Vector3(Random.Range(-4.0f, 10.0f), 2.7f, Random.Range(9.0f, -8.0f));
            return randomPosition;
        }

        private Color GetColor(BallType ballType)
        {
            return ballType switch
            {
                BallType.Red => Color.red,
                BallType.Green => Color.green,
                _ => throw new ArgumentOutOfRangeException(nameof(ballType), ballType, null)
            };
        }
        
        private void AddForceBalls()
        {
            foreach (var entity in _entities)
            {
                var speed = entity.ballComponents.speed;
                
                var randomForce =
                    new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)) * speed;
                entity.ballComponents.force = randomForce;
            }
        }
    }
}