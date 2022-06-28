using Morpeh;
using UnityEngine;

namespace Code.Units.Utility
{
    public class CollisionPool
    {
        private World _world;
        
        public CollisionPool(World world)
        {
            _world = world;
        }
        
        public Entity Get()
        {
            var entity = _world.CreateEntity();
            return entity;
        }
    }
}
