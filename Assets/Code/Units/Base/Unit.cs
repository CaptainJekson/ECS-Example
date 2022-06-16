using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.Base
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct Unit : IComponent
    {
        public Transform transform;
        public Rigidbody rigidbody;
        public MeshRenderer meshRenderer;
        public float speed;
    }
}