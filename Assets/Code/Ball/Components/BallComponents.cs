using Code.Ball.Types;
using Entitas;
using UnityEngine;

public class BallComponents : IComponent
{
    public Transform transform;
    public Rigidbody rigidbody;
    public MeshRenderer meshRenderer;
    public float speed;

    public BallType ballType;
    public Vector3 force;
}