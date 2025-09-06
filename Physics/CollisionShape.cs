using Microsoft.Xna.Framework;
using GameMonoStudy.Engine.Geometry;
using System.Linq;
using System;

namespace Engine.Physics;

class ImplCollisionShape : CollisionShape
{
    public Shape CollidableShape;

    private Vector2[] thisVertices
    {
        get
        {
            return this.CollidableShape.GetVertices();
        }
    }

    private Vector2[] thisNormales
    {
        get
        {
            return this.CollidableShape.GetNormalAxes();
        }
    }
    public bool isColliding(CollisionShape otherShape)
    {;
        Vector2[] otherNormales = otherShape.GetNormalAxes();

        Vector2[] axes = thisNormales.Concat(otherNormales).ToArray();

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

    public CollideInfo GetCollideInfo(CollisionShape otherShape)
    {
        if (!this.isColliding(otherShape))
        {
            return CollideInfo.empty;
        }
        
        Vector2[] otherNormales = otherShape.GetNormalAxes();
        Vector2[] axes = thisNormales.Concat(otherNormales).ToArray();

        float minOverlap = float.PositiveInfinity;
        Vector2 minAxis = Vector2.Zero;

        foreach (Vector2 axis in axes)
        {
            (float Min1, float Max1) = this.CollidableShape.GetProjection(thisVertices, axis);
            (float Min2, float Min2) projection2 = otherShape.CollidableShape.GetProjection(otherVertices, axis);

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
}