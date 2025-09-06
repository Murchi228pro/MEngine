using Microsoft.Xna.Framework;

namespace Engine.Geometry

public abstract class Shape {
    
    public Vector2 Center;
    public float Rotation;

    public abstract (float, float) GetProjection(Vector2 axis);

    public abstract GetNormalAxes();
}