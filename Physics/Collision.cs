
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using Engine.Geometry;
using Microsoft.Xna.Framework;

namespace Engine.Physics;

public class CollisionShape()
{
    public Shape CollidableShape;
    public virtual bool isColliding(CollisionShape c)
    {
        return false;
    }
    public virtual CollideInfo GetCollideInfo(CollisionShape c)
    {
        return CollideInfo.empty;
    }
    protected List<Vector2> GetAxes() {
        return new List<Vector2>();
    }
}

public struct CollideInfo
{
    public Vector2 mtv;
    public float overlap;
    public Vector2 axis;

    public static CollideInfo empty
    {
        get
        {
            return new CollideInfo(Vector2.Zero, 0, Vector2.Zero);
        }
    }
    public CollideInfo(Vector2 mtv_, float overlap_, Vector2 axis_)
    {
        this.mtv = mtv_;
        this.overlap = overlap_;
        this.axis = axis_;
    }
    

}