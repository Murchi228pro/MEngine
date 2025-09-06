using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Engine.Geometry;

public class Rect
{
    public Vector2 Center;
    public float Rotation;
    public float Width;
    public float Height;

    public Rect(Vector2 center, float width, float height, float rotation = 0)
    {
        this.Center = center;
        this.Width = width;
        this.Height = height;
        this.Rotation = rotation;
    }

    public Vector2[] GetVertices()
    {
        float cos = (float)Math.Cos(this.Rotation);
        float sin = (float)Math.Sin(this.Rotation);

        float halfWidth = this.Width / 2;
        float halfHeight = this.Height / 2;

        Vector2[] vertices = {
            new Vector2(-halfWidth, -halfHeight),
            new Vector2(-halfWidth, halfHeight),
            new Vector2(halfWidth, halfHeight),
            new Vector2(halfWidth, -halfHeight)
        };

        for (int i = 0; i < vertices.Length; i++)
        {
            float rotatedX = (vertices[i].X * cos - vertices[i].Y * sin);
            float rotatedY = (vertices[i].X * sin + vertices[i].Y * cos);
            vertices[i] = new Vector2(Center.X + rotatedX, Center.Y + rotatedY);
        }

        return vertices;
    }
    public Vector2[] 
}