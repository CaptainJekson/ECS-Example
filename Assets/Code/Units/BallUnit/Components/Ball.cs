using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.BallUnit.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct Ball : IComponent
    {
        public BallType ballType;
        public MeshRenderer meshRenderer;
        public Vector3 force;
    }
}