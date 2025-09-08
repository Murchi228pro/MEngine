using Microsoft.Xna.Framework;
using Engine.Geometry;
using System.Linq;
using System;
using System.Collections.Generic;

namespace Engine.Physics
{

    public class ImplCollisionShape : CollisionShape
    {
        public ImplCollisionShape(){}
        public override bool isColliding(CollisionShape otherShape)
        {
            List<Vector2> axes = this.GetAxes(otherShape);

            foreach (Vector2 axis in axes)
            {
                axis.Normalize();
                (float Min1, float Max1) = this.CollidableShape.GetProjection(axis);
                (float Min2, float Max2) = otherShape.CollidableShape.GetProjection(axis);

                if (Max1 < Min2 || Max2 < Min1)
                {
                    return false;
                }
            }
            return true;
        }

        public override CollideInfo GetCollideInfo(CollisionShape otherShape)
        {
            if (!this.isColliding(otherShape))
            {
                return CollideInfo.empty;
            }
            List<Vector2> axes = this.GetAxes(otherShape);

            float minOverlap = float.PositiveInfinity;
            Vector2 minAxis = Vector2.Zero;

            foreach (Vector2 axis in axes)
            {
                axis.Normalize();
                (float Min1, float Max1) = this.CollidableShape.GetProjection(axis);
                (float Min2, float Max2) = otherShape.CollidableShape.GetProjection(axis);

                float overlap = Math.Min(Max1 - Min2, Max2 - Min1);

                if (overlap < minOverlap)
                {
                    minOverlap = overlap;
                    minAxis = axis;
                }
            }

            Vector2 direction = otherShape.CollidableShape.Center - this.CollidableShape.Center;
            int mtvDirection = Vector2.Dot(direction, minAxis) > 0 ? -1 : 1;

            return new CollideInfo(minAxis * mtvDirection * minOverlap,
                minOverlap,
                minAxis
            );
        }

        protected List<Vector2> GetAxes(CollisionShape other)
        {
            List<Vector2> axes = new List<Vector2>();
            axes.AddRange(this.CollidableShape.GetNormalAxes());
            axes.AddRange(other.CollidableShape.GetNormalAxes());
            axes.Add(Vector2.Normalize(this.CollidableShape.Center - other.CollidableShape.Center));
            return axes;
        }
    }
}