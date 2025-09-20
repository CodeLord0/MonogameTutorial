using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;


namespace SpaceShip;

public class Controller
{
    public double timer = 2D;
    public double MaxTime = 2D;
    public int nexSpeed = 240;
    public List<Asteroid> asteroids = new List<Asteroid>();
    public bool inGame = false;
    public float totalTime = 0f;


    
    public void ConUpdate(GameTime gameTime)
    {

        if (inGame)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds;
            totalTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        else
        {
            KeyboardState kState = Keyboard.GetState();
            {
                if (kState.IsKeyDown(Keys.Enter))
                {
                    inGame = true;
                    totalTime = 0f;
                    timer = 2D;
                    MaxTime = 2D;
                    nexSpeed = 240;
                }
            }
        }

        if (timer <= 0)
        {
            asteroids.Add(new Asteroid(nexSpeed));
            timer = MaxTime;


            if (timer > 0.5)
            {
                MaxTime -= 0.1D;
            }
            if (nexSpeed < 720)
            {
                nexSpeed += 4;
            }


        }

    }

}
