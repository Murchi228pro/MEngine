using Microsoft.Xna.Framework;
using System;

namespace Engine.Geometry
{
    public class GeometryHelper
    {

        public static Vector2 GetNormal(Vector2 point1, Vector2 point2)
        {
            Vector2 edge = point2 - point1;

            return GetNormal(edge);
        }
        public static Vector2 GetNormal(Vector2 edge)
        {
            Vector2 v = new Vector2(-edge.Y, edge.X);
            v.Normalize();
            return v;
        }

        public static Vector2 RotateAtX(float X, float angle)
        {
            float rotatedX = (float)Math.Cos(angle) * X;
            float rotatedY = (float)Math.Sin(angle) * X;
            return new Vector2(rotatedX, rotatedY);
        }
        public static Vector2 RotateAtY(float Y, float angle)
        {
            float rotatedX = -(float)Math.Sin(angle) * Y;
            float rotatedY = (float)Math.Cos(angle) * Y;
            return new Vector2(rotatedX, rotatedY);
        }
        public static Vector2 Rotate(Vector2 pos, float angle)
        {
            Vector2 RotatedX = RotateAtX(pos.X, angle);
            Vector2 RotatedY = RotateAtY(pos.Y, angle);
            return new Vector2(RotatedX.X + RotatedY.X, RotatedX.Y + RotatedY.Y);
        }
        public static Vector2 MirrorVector(Vector2 current, Vector2 axis)
        {
            Vector2 mirroredAtX = new Vector2(current.X, -current.Y);
            double mirrorAngle = Math.Atan2(mirroredAtX.Y, mirroredAtX.X) + Math.Atan2(axis.Y, axis.X);
            Vector2 mirroredVector = Rotate(current, (float)mirrorAngle);
            return mirroredVector;
        }
    }
}