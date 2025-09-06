using Microsoft.Xna.Framework;
using System;

namespace Engine.Geometry
{
    public class GeometryHelper
    {
        
        public static Vector2[] GetNormals(Vector2[] vertices)
        {
            Vector2[] normals = new Vector2[4];

            for (int i = 0; i < 4; i++)
            {
                Vector2 p1 = vertices[i];
                Vector2 p2 = vertices[(i + 1) % 4];

                Vector2 normal = GetNormal(p1, p2);
                normals[i] = normal;
            }

            return normals;
        }
        public static Vector2 GetNormal(Vector2 point1, Vector2 point2)
        {
            Vector2 edge = point2 - point1;

            return GetNormal(edge);
        }
        public static Vector2 GetNormal(Vector2 edge)
        {
            return new Vector2(-edge.Y, edge.X);
        }
    }
}