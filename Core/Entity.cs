
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine.Core;

public class Entity
{
    private uint _rid;
    private Entity _parent;
    private List<Entity> _children;
    private HashSet<string> _groups;
    private HashSet<Component> _components;
    public Vector2 Position;

    public void Start()
    {
        
    }
    public void Update()
    {

    }

}