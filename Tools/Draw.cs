using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Tools;

public class Draw
{
    Texture2D pixel;
    public Draw(GraphicsDevice graphicsDevice)
    {
        pixel = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);
        pixel.SetData<Color>(new[] { Color.White });
    }
    public void DrawPixel(SpriteBatch spriteBatch, Vector2 pos, Color color)
    {
        spriteBatch.Draw(pixel, pos, color);
    }
    public void DrawPixel(SpriteBatch spriteBatch, Vector2 pos)
    {
        this.DrawPixel(spriteBatch, pos, Color.White);
    }
    public void DrawLine(SpriteBatch spriteBatch, Vector2 startPos, Vector2 endPos, Color color)
    {
        bool atY = false;
        if (Math.Abs(endPos.Y - startPos.Y) > Math.Abs(endPos.X - startPos.X))
        {
            (startPos.X, startPos.Y) = (startPos.Y, startPos.X);
            (endPos.X, endPos.Y) = (endPos.Y, endPos.X);
            atY = true;
        }
        if (endPos.X < startPos.X)
        {
            (startPos, endPos) = (endPos, startPos);
        }

        float dx = endPos.X - startPos.X;
        float error = dx / 2;
        float dy = Math.Abs(endPos.Y - startPos.Y);
        int yStep = (startPos.Y < endPos.Y) ? 1 : -1;
        float y = startPos.Y;
        for (float x = startPos.X; x < endPos.X; x++)
        {
            Vector2 pos = atY ? new Vector2(y, x) : new Vector2(x, y);
            this.DrawPixel(spriteBatch, pos, color);
            error -= dy;
            if (error < 0)
            {
                y += yStep;
                error += dx;
            }
        }

    }
    public void DrawLine(SpriteBatch spriteBatch, Vector2 startPos, Vector2 endPos)
    {
        this.DrawLine(spriteBatch, startPos, endPos, Color.White);
    }

    public void DrawCircle(SpriteBatch spriteBatch, Vector2 position, float radius)
    {
        for (float angle = 0; angle < 365; angle += 5.5f)
        {
            float x = (float)Math.Cos(angle) * radius;
            float y = (float)Math.Sin(angle) * radius;
            DrawPixel(spriteBatch, position + new Vector2(x, y));
        }
    }
    
}