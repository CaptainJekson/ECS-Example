using Code.Units.BallUnit.Components;
using Code.Units.BallUnit.EventComponents;
using Code.Units.BallUnit.Systems;
using Code.Units.Walls;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.BallUnit.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class BallProvider : MonoProvider<Ball>
    {
        public void OnCollisionEnter(Collision other)
        {
            var normal = new Vector3(other.contacts[0].normal.x, 0.0f, other.contacts[0].normal.z);
            
            if (other.collider.GetComponent<WallProvider>())
            {
                if (Entity.Has<ReflectBallEvent>() == false)
                {
                    ref var reflectBallEvent = ref Entity.AddComponent<ReflectBallEvent>();
                    reflectBallEvent.normal = normal;
                }
            }
            
            if (other.collider.GetComponent<BallProvider>())
            {
                if (Entity.Has<ReflectBallEvent>() == false)
                {
                    ref var typeCurrentBall = ref Entity.GetComponent<Ball>().ballType;
                    ref var typeCollisionBall = ref other.collider.GetComponent<BallProvider>()
                        .Entity.GetComponent<Ball>().ballType;

                    if (typeCurrentBall == typeCollisionBall)
                    {
                        ref var collisionEvent = ref Entity.AddComponent<ReflectBallEvent>();
                        collisionEvent.normal = normal;
                    }
                }
            }
        }

        public void OnCollisionStay(Collision other)
        {
            if (other.collider.GetComponent<BallProvider>())
            {
                ref var typeCurrentBall = ref Entity.GetComponent<Ball>().ballType;
                ref var typeCollisionBall = ref other.collider.GetComponent<BallProvider>()
                    .Entity.GetComponent<Ball>().ballType;

                if (typeCurrentBall != typeCollisionBall)
                {
                    if (Entity.Has<ReduceBallEvent>() == false)
                    {
                        ref var reduceBallEvent = ref Entity.AddComponent<ReduceBallEvent>();
                        reduceBallEvent.otherBall = other.collider.GetComponent<BallProvider>();
                    }
                }
            }
        }

        public void OnCollisionExit(Collision other)
        {
            if (other.collider.GetComponent<BallProvider>())
            {
                if (Entity.Has<ReduceBallEvent>())
                {
                    Entity.RemoveComponent<ReduceBallEvent>();
                }
            }
        }
    }
}