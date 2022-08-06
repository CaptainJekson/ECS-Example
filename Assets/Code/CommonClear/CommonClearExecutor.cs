using Code.CommonClear.Systems;
using Morpeh;

namespace Code.CommonClear
{
    public class CommonClearExecutor : Executor
    {
        public CommonClearExecutor(World world,
            DestroyEntitySystem destroyEntitySystem) : base(world)
        {
            _lateUpdateSystems.AddSystem(destroyEntitySystem);
        }
    }
}