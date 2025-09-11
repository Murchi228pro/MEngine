using Microsoft.Xna.Framework;
using Engine.Core;


namespace Engine.Physics
{
    class PhysicsBody:Entity
    {
        CollisionShape collisionShape;
        public PhysicsBody(CollisionShape collisionShape_)
        {
            collisionShape = collisionShape_;
        }
        public void Update(float deltaTime)
        {

        }
    }
}