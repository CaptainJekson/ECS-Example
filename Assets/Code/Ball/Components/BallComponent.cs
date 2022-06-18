using Entitas;
using UnityEngine;

namespace Code.Ball.Components
{
    public class BallComponent : IComponent
    {
        public Transform transform;
        public Rigidbody rigidBody;
        public MeshRenderer meshRenderer;
        public float speed;
        public BallType ballType;
        public Vector3 force;
    }
}
