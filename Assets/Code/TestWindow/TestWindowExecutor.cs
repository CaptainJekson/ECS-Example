using Code.TestWindow.Systems;
using Morpeh;

namespace Code.TestWindow
{
    public class TestWindowExecutor : Executor
    {
        public TestWindowExecutor(World world, 
            TestWindowCreateSystem testWindowCreateSystem, 
            TestWindowInitializeSystem testWindowInitializeSystem, 
            TestWindowInitializeFinishedSystem testWindowInitializeFinishedSystem, 
            TestWindowSendPressedSystem testWindowSendPressedSystem,
            TestWindowCloseSystem testWindowCloseSystem) : base(world)
        {
            _updateSystems.AddSystem(testWindowCreateSystem);
            _updateSystems.AddSystem(testWindowInitializeSystem);
            _updateSystems.AddSystem(testWindowInitializeFinishedSystem);
            _updateSystems.AddSystem(testWindowSendPressedSystem);
            _updateSystems.AddSystem(testWindowCloseSystem);
        }
    }
}