using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace SpaceShip;

public class Ship
{
    public Vector2 position = defaultPosition;
 
    
    
    const int speed = 180;
    static public Vector2 defaultPosition = new Vector2(683,384);
    
    float dt;


    public void ShipUpdate(GameTime gameTime, Controller gameController)
    {
        dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState Kstate = Keyboard.GetState();
        Vector2 direction = Vector2.Zero;


        if (gameController.inGame)
        {
            if (Kstate.IsKeyDown(Keys.Right) && position.X < 1366)
            {
                // position.Normalize();
                direction.X = 1;
                //position.X += speed * dt * direction.X;//
            }
            if (Kstate.IsKeyDown(Keys.Left) && position.X > 0)
            {
                //position.Normalize();
                direction.X = -1;
                //position.X -= speed * dt * direction.X;//
            }
            if (Kstate.IsKeyDown(Keys.Up) && position.Y > 0)
            {
                //position.Normalize();
                direction.Y = -1;
                //position.Y -= speed * dt * direction.Y;//
            }
            if (Kstate.IsKeyDown(Keys.Down) && position.Y < 768)
            {
                //position.Normalize();
                direction.Y = 1;
                //position.Y += speed * dt * direction.Y;//
            }
            if (direction != new Vector2(0, 0))
            {
                direction.Normalize();
                position += speed * dt * direction;
            }
            

        }
    }
}
