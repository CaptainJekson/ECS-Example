using Code.Units.Base.Components;
using Code.Units.Utility;
using Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Code.Units.Base.Providers
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public sealed class CollidableObjectProvider : MonoProvider<CollidableObject>
    {
        private CollisionPool _collisionPool;
        
        public void Init(CollisionPool collisionPool)
        {
            _collisionPool = collisionPool;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var entity = _collisionPool.Get();
            entity.SetComponent(new CollisionInfo
            {
                currentEntity = Entity,
                otherCollision = other,
            });
        }
    }
}