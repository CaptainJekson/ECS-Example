using System;
using System.Collections.Generic;
using Code.Units.Base.Components;
using Morpeh;

namespace Code.Units.Utility
{
    public class CollisionPool
    {
        private World _world;
        private Stack<Entity> _pool;
        
        public CollisionPool(World world)
        {
            _world = world;
            _pool = new Stack<Entity>();
        }

        public Entity Get()
        {
            var isPoolEntry = _pool.TryPop(out var entity);

            if (!isPoolEntry)
            {
                entity = GenerateNewEntity();
            }

            return entity;
        }

        public void Return(Entity entity)
        {
            entity.RemoveComponent<CollisionInfo>();
            _pool.Push(entity);
        }
        
        private Entity GenerateNewEntity()
        {
            var entity = _world.CreateEntity();
            entity.AddComponent<CollisionEvent>();
            return entity;
        }
    }
}
