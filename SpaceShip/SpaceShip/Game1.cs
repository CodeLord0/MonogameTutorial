 using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShip;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D shipSprite;
    Texture2D asteroidSprite;
    Texture2D spaceSprite;
    SpriteFont gameFont;
    SpriteFont timerFont;
    Ship player = new Ship();
    Controller gameController = new Controller();


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        _graphics.PreferredBackBufferWidth = 1366;
        _graphics.PreferredBackBufferHeight = 768;

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
        
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        shipSprite = Content.Load<Texture2D>("ship");
        spaceSprite = Content.Load<Texture2D>("space");
        asteroidSprite = Content.Load<Texture2D>("asteroid");
        gameFont = Content.Load<SpriteFont>("spaceFont");
        timerFont = Content.Load<SpriteFont>("timerFont");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        player.ShipUpdate(gameTime,gameController);

        gameController.ConUpdate(gameTime);

        for (int i = 0; i < gameController.asteroids.Count; i++)
        {
            
            gameController.asteroids[i].asteroidUpdate(gameTime);

            if (gameController.asteroids[i].position.X < 0 - gameController.asteroids[i].radius)
            {
                gameController.asteroids[i].offScreen = true;
            }

            
            int sum = gameController.asteroids[i].radius + 30;

            if (Vector2.Distance(gameController.asteroids[i].position, player.position) < sum)
            {
                gameController.inGame = false;
                player.position = Ship.defaultPosition;
                i = gameController.asteroids.Count;
                gameController.asteroids.Clear();

            }
    
        }
        gameController.asteroids.RemoveAll(a => a.offScreen);


        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin();
        _spriteBatch.Draw(spaceSprite, new Vector2(0, 0),Color.White);

        _spriteBatch.Draw(shipSprite, new Vector2(player.position.X - 34 ,player.position.Y -  50), Color.White);
        
        if (gameController.inGame == false)
        {
            string menuMessage = "Press Enter to Begin";
            Vector2 sizeOfText = gameFont.MeasureString(menuMessage);
            _spriteBatch.DrawString(gameFont, menuMessage, new Vector2(683 - sizeOfText.X / 2, 200), Color.White);

        }
        
        for (int i = 0; i < gameController.asteroids.Count; i++)
        {
            Vector2 tempPos = gameController.asteroids[i].position;
            int tempRaidus = gameController.asteroids[i].radius;
             
            _spriteBatch.Draw(asteroidSprite, new Vector2(tempPos.X - tempRaidus, tempPos.Y - tempRaidus), Color.White);
        }
        _spriteBatch.DrawString(timerFont, "Time: " + Math.Floor(gameController.totalTime).ToString(), new Vector2(3, 3), Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
