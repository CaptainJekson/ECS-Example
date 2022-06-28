using Code.Units.Base.Components;
using Code.Units.Utility;
using Morpeh;

namespace Code.Units.Base.Systems
{
    public class CollisionCleanupSystem : ILateSystem
    {
        private Filter _filter;
        private CollisionPool _collisionPool;
        
        public World World { get; set; }

        public CollisionCleanupSystem(CollisionPool collisionPool)
        {
            _collisionPool = collisionPool;
        }
        
        public void OnAwake()
        {
            _filter = World.Filter.With<CollisionInfo>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                _collisionPool.Return(entity);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}