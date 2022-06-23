using Code.UI.GameInterfaceWindow.Systems;
using Morpeh;

namespace Code.UI
{
    public class UiSystemsExecutor : Executor
    {
        public UiSystemsExecutor(World world, ShowCounterSystem showCounterSystem, TimeScaleSystem timeScaleSystem) 
            : base(world)
        {
            _updateSystems.AddSystem(showCounterSystem);
            _updateSystems.AddSystem(timeScaleSystem);  
        }
    }
}