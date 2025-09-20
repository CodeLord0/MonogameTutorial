using System;
using System.Numerics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace SpaceShip;

public class Asteroid
{
    public Vector2 position;
    public int speed = 220;
    public int radius = 59;
    public double maxTime;
    public bool offScreen = false;
    static Random rand = new Random();
    public Asteroid(int newSpeed)
    {
        speed = newSpeed;

        position = new Vector2(1366 + radius, rand.Next(0, 769));

    }

    public void asteroidUpdate(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
        position.X -= speed * dt;
        


    }

}
