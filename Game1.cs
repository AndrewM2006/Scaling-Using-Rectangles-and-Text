using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Scaling_Using_Rectangles_and_Text
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D blackTexture;
        Texture2D whiteTexture;
        SpriteFont titleFont;
        int xValue, yValue;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 640;
            _graphics.PreferredBackBufferWidth = 640;
            _graphics.ApplyChanges();
            this.Window.Title = "Chess Board";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Random generator = new Random();
            xValue = generator.Next(_graphics.PreferredBackBufferWidth);
            yValue = generator.Next(_graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            blackTexture = Content.Load<Texture2D>("BlackSquare");
            whiteTexture = Content.Load<Texture2D>("WhiteSquare");
            titleFont = Content.Load<SpriteFont>("Title");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0; i < _graphics.PreferredBackBufferHeight; i+=_graphics.PreferredBackBufferHeight/4)
            {
                for (int j = 0; j < _graphics.PreferredBackBufferWidth; j+=_graphics.PreferredBackBufferWidth/4)
                {
                    _spriteBatch.Draw(whiteTexture, new Rectangle (j, i, _graphics.PreferredBackBufferWidth / 8, _graphics.PreferredBackBufferHeight / 8), Color.White);
                    _spriteBatch.Draw(blackTexture, new Rectangle(j+ _graphics.PreferredBackBufferWidth / 8, i, _graphics.PreferredBackBufferWidth / 8, _graphics.PreferredBackBufferHeight / 8), Color.White);
                    _spriteBatch.Draw(blackTexture, new Rectangle(j, i + _graphics.PreferredBackBufferHeight / 8, _graphics.PreferredBackBufferWidth / 8, _graphics.PreferredBackBufferHeight / 8), Color.White);
                    _spriteBatch.Draw(whiteTexture, new Rectangle(j + _graphics.PreferredBackBufferWidth / 8, i + _graphics.PreferredBackBufferHeight / 8, _graphics.PreferredBackBufferWidth / 8, _graphics.PreferredBackBufferHeight / 8), Color.White);
                }
            }
            _spriteBatch.DrawString(titleFont, "Chess", new Vector2 (xValue, yValue), Color.SkyBlue);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}