using Code.TestWindow.Components;
using Morpeh;

namespace Code.TestWindow.Systems
{
    public class TestWindowInitializeFinishedSystem : ISystem
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
                entity.RemoveComponent<TestWindowInitializeComponent>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}