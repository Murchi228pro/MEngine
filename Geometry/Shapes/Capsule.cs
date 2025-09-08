// Capsule - Shape inherinstanced class
using Microsoft.Xna.Framework;
using Engine.Geometry;
using System;

class Capsule : Shape
{
    Vector2 Height;
    float Radius;

    public override (float, float) GetProjection(Vector2 axis)
    {
        throw new System.NotImplementedException();

    }

    public override Vector2[] GetNormalAxes()
    {
        throw new System.NotImplementedException();
    }
    
}