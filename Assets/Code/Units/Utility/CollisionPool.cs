using System;
using System.Collections.Generic;
using Code.Units.Base.Components;
using Morpeh;
using UnityEngine;

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

        public Entity GenerateNewEntity()
        {
            var entity = _world.CreateEntity();
            entity.AddComponent<CollisionEvent>();
            return entity;
        }
        
        public Entity Get()
        {
            Entity entity;
            
            try
            {
                entity = _pool.Pop();
            }
            catch (Exception e)
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
    }
}
