// Capsule - Shape inherinstanced class
using Microsoft.Xna.Framework;
using System;

namespace Engine.Geometry;

class Capsule : Shape
{
    float Height;
    float Radius;

    public override (float, float) GetProjection(Vector2 axis)
    {
        Vector2 rotatedVector = GeometryHelper.RotateAtY(1, Rotation);
        Vector2 circleCenter1 = rotatedVector * Height / 2;
        Vector2 circleCenter2 = rotatedVector * (-Height / 2);
        Vector2[] points = {
            circleCenter1 + Radius * axis,
            circleCenter1 - Radius * axis,
            circleCenter2 + Radius * axis,
            circleCenter2 - Radius * axis
        };

        float Min = float.PositiveInfinity;
        float Max = float.NegativeInfinity;

        foreach (Vector2 point in points)
        {
            Min = Math.Min(Min, Vector2.Dot(point, axis));
            Max = Math.Max(Max, Vector2.Dot(point, axis));
        }
        return (Min, Max);
    }

    public override Vector2[] GetNormalAxes()
    {
        Vector2 axis = GeometryHelper.RotateAtY(1, Rotation);
        return new Vector2[] { GeometryHelper.GetNormal(axis) };
    }

}