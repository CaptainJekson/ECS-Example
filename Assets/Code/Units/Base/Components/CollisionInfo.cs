using Morpeh;
using UnityEngine;

namespace Code.Units.Base.Components
{
    public struct CollisionInfo : IComponent
    {
        public Entity currentEntity;
        public Collision otherCollision;
    }
}