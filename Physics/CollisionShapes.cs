using Microsoft.Xna.Framework;
using GameMonoStudy.Engine.Geometry;
using System.Linq;
using System;

namespace Engine.Physics;

class RectangleCollisionShape : CollisionShape
{
    public Rect Shape;

    private Vector2[] thisVertices
    {
        get
        {
            return this.Shape.GetVertices();
        }
    }

    private Vector2[] thisNormales
    {
        get
        {
            return this.Shape.GetVertices();
        }
    }
    public bool isColliding(RectangleCollisionShape otherShape)
    {

        Vector2[] otherVertices = otherShape.Shape.GetVertices();
        Vector2[] otherNormales = GeometryHelper.GetNormals(otherVertices);

        Vector2[] axes = thisNormales.Concat(otherNormales).ToArray();

        foreach (Vector2 axis in axes)
        {
            axis.Normalize();
            (float, float) projection1 = GeometryHelper.GetProjection(thisVertices, axis);
            (float, float) projection2 = GeometryHelper.GetProjection(otherVertices, axis);

            if (projection1.Item2 < projection2.Item1 || projection2.Item2 < projection1.Item1)
            {
                return false;
            }
        }
        return true;
    }

    public CollideInfo GetCollideInfo(RectangleCollisionShape otherShape)
    {
        if (!this.isColliding(otherShape))
        {
            return CollideInfo.empty;
        }
        Vector2[] otherVertices = otherShape.Shape.GetVertices();
        Vector2[] otherNormales = GeometryHelper.GetNormals(otherVertices);

        Vector2[] axes = thisNormales.Concat(otherNormales).ToArray();

        float minOverlap = float.PositiveInfinity;
        Vector2 minAxis = Vector2.Zero;

        foreach (Vector2 axis in axes)
        {
            axis.Normalize();
            (float, float) projection1 = GeometryHelper.GetProjection(thisVertices, axis);
            (float, float) projection2 = GeometryHelper.GetProjection(otherVertices, axis);
            
            // Item2 - Max    Item1 - Min
            float overlap = Math.Min(projection1.Item2 - projection2.Item1, projection2.Item2 - projection1.Item1);

            if (overlap < minOverlap)
            {
                minOverlap = overlap;
                minAxis = axis;
            }
        }
        Vector2 direction = otherShape.Shape.Center - this.Shape.Center;
        int mtvDirection = Vector2.Dot(direction, minAxis) > 0 ? -1 : 1;

        return new CollideInfo(minAxis * mtvDirection * minOverlap,
            minOverlap,
            minAxis
        );
    }
}