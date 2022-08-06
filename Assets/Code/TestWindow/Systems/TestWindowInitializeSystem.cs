using Code.TestWindow.Components;
using Code.Utility;
using Morpeh;

namespace Code.TestWindow.Systems
{
    public class TestWindowInitializeSystem : ISystem
    {
        public World World { get; set; }
        
        private Filter _filter;
        
        public void OnAwake()
        {
            _filter = World.Filter.With<TestWindowDataComponent>().With<TestWindowInitializeComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var data = ref entity.GetComponent<TestWindowDataComponent>();
                data.provider.sendButton.OnClickAdd<TestWindowSendPressedComponent>(entity);
                data.provider.closeButtons.OnClickAdd<TestWindowCloseComponent>(entity);
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}