// Circle - Shape inherinstanced class
using System;
using Microsoft.Xna.Framework;

namespace Engine.Geometry
{
    public class Circle : Shape
    {
        public float Radius;
        public Circle(Vector2 position, float radius)
        {
            this.Center = position;
            this.Radius = radius;
        }
        public override (float, float) GetProjection(Vector2 axis)
        {
            float proj1 = Vector2.Dot(Center + axis * Radius, axis);
            float proj2 = Vector2.Dot(Center + (-axis * Radius), axis);
            float min = Math.Min(proj1, proj2);
            float max = Math.Max(proj1, proj2);
            return (min, max);
        }
        public override Vector2[] GetNormalAxes()
        {
            return new Vector2[] { };
        }
    }
}

