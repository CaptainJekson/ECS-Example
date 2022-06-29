using Code.Units.BallUnit.Components;
using Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Units.BallUnit.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class BallProvider : MonoProvider<Ball>
    {
        
    }
}