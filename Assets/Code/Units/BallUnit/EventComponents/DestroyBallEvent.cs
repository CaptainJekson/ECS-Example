using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Units.BallUnit.EventComponents
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [System.Serializable]
    public struct DestroyBallEvent : IComponent 
    {
        public BallType ballType; 
    }
}