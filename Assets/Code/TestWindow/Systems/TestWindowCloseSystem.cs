using Code.CommonClear.Components;
using Code.TestWindow.Components;
using DG.Tweening;
using Morpeh;
using UnityEngine;

namespace Code.TestWindow.Systems
{
    public class TestWindowCloseSystem : ISystem
    {        
        public World World { get; set; }
        private Filter _filter;
        
        public void OnAwake()
        {
            _filter = World.Filter.With<TestWindowComponent>().With<TestWindowDataComponent>().With<TestWindowCloseComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var dataComponent = ref entity.GetComponent<TestWindowDataComponent>();
                Object.Destroy(dataComponent.gameObject);
                entity.SetComponent(new DestroyComponent());
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}