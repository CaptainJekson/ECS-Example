using Code.TestWindow.Components;
using Morpeh;
using UnityEngine;

namespace Code.TestWindow.Systems
{
    public class TestWindowSendPressedSystem : ISystem
    {     
        public World World { get; set; }

        private Filter _filter;
        
        public void OnAwake()
        {
            _filter = World.Filter.With<TestWindowDataComponent>().With<TestWindowSendPressedComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var dataComponent = ref entity.GetComponent<TestWindowDataComponent>();
                dataComponent.provider.messageText.text = Random.Range(1, 10000000).ToString();

                entity.RemoveComponent<TestWindowSendPressedComponent>();
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}