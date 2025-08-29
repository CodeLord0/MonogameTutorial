using System;
using System.Numerics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = Microsoft.Xna.Framework.Vector2;

namespace MonogameTutorial;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Texture2D targetSprite;
    Texture2D crosshairSprite;
    Texture2D backgroundSprite;
    SpriteFont gameFont;
    Vector2 targetPosition = new Vector2(200,50);
    const int targetRaidus = 45;
    MouseState mstate;
    int score;
    bool mReleased = true;
    
    //int screenWidth = GraphicsDevice.Viewport.Width;



    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        backgroundSprite = Content.Load<Texture2D>("sky");
        targetSprite = Content.Load<Texture2D>("target");
        gameFont = Content.Load<SpriteFont>("galleryFont");
        crosshairSprite = Content.Load<Texture2D>("crosshairs");
    }

    protected override void Update(GameTime gameTime)
    {
        Mouse.SetCursor(MouseCursor.FromTexture2D(crosshairSprite, 0, 0));
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        mstate = Mouse.GetState();
        if (mstate.LeftButton == ButtonState.Pressed && mReleased == true)
        {
            float mouseDistance = Vector2.Distance(targetPosition,mstate.Position.ToVector2());
            System.Console.WriteLine(Vector2.Distance(targetPosition,mstate.Position.ToVector2()));

            if (mouseDistance < targetRaidus)
            {
                score++;
                Random rand = new Random();
                targetPosition.X = rand.Next(0, _graphics.PreferredBackBufferWidth);
                targetPosition.Y = rand.Next(0, _graphics.PreferredBackBufferHeight);  
            }

            mReleased = false;
            
        }
        if (mstate.LeftButton == ButtonState.Released)
        {
            mReleased = true;
        }
        
        



        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
        _spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X- targetRaidus,targetPosition.Y-targetRaidus), Color.White);
        _spriteBatch.DrawString(gameFont, score.ToString(),new Vector2(00,200),Color.Beige);
        //_spriteBatch.Draw(crosshairSprite)
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
