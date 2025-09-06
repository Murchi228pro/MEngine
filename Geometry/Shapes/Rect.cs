using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Engine.Geometry;

public class Rect : Shape
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
    public (float, float) GetProjection(Vector2 axis)
        {
            Vector2[] vertices = this.GetVertices();

            float min = float.PositiveInfinity;
            float max = float.NegativeInfinity;

            for (int i = 0; i < vertices.Length; i++)
            {
                min = Math.Min(min, Vector2.Dot(vertices[i], axis));
                max = Math.Max(max, Vector2.Dot(vertices[i], axis));
            }

            return (min, max);
        }
    public Vector2[] GetNormalAxes(){

        Vector2[] normals = new Vector2[4];
        Vector2[] vertices = this.GetVertices();

        for (int i = 0; i < 4; i++)
        {
            Vector2 p1 = vertices[i];
            Vector2 p2 = vertices[(i + 1) % 4];

            Vector2 normal = GeometryHelper.GetNormal(p1, p2);
            normals[i] = normal;
        }
        return normals;
    }
}