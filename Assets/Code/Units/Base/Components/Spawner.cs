using Code.Units.BallUnit.Providers;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.Base.Components
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct Spawner : IComponent
    {
        public BallProvider ball;
        
        public Transform ballsParent;
        public int countRed;
        public int countGreen;
    }
}