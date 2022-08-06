using Code.CommonClear.Components;
using Morpeh;

namespace Code.CommonClear.Systems
{
    public class DestroyEntitySystem : ILateSystem
    {       
        public World World { get; set; }

        private Filter _filter;
        
        public void OnAwake()
        {
            _filter = World.Filter.With<DestroyComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                World.RemoveEntity(entity);
            }
        }
        
        public void Dispose()
        {
            _filter = null;
        }
    }
}