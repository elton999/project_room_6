using UmbrellaToolsKit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AssetManagement _assetManagement;
        private GameManagement _gameManagement;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 426 * 3;
            _graphics.PreferredBackBufferHeight = 240 * 3;
            _graphics.ApplyChanges();

            _gameManagement = new GameManagement();
            _gameManagement.Game = this;
            _gameManagement.Start();

            _assetManagement = new AssetManagement();
            _assetManagement.Set<Entities.Player.Player>("Player", "PLAYER");
            _assetManagement.Set<Entities.Door>("Door", "MIDDLEGROUND");
            _assetManagement.Set<GameObject>("PlayerSpawn", "MIDDLEGROUND");

            _assetManagement.Set<Entities.Solids.Box>("Box", "MIDDLEGROUND");
            _assetManagement.Set<Entities.Solids.SolidBox>("SolidBlock", "MIDDLEGROUND");
            _assetManagement.Set<Entities.Actors.GroundButton>("GroundButton", "BACKGROUND");
            _assetManagement.Set<Entities.Actors.Items.Key>("Key", "FOREGROUND");

            _assetManagement.Set<GamePlay.PuzzleButtons>("PuzzleButtons", "BACKGROUND");

            _gameManagement.SceneManagement.Start();
            _gameManagement.SceneManagement.MainScene.SetBackgroundColor = new Color((new Vector3(139, 147, 175)) / 255.0f);

            // blurSprite = new RenderTarget2D(_graphics.GraphicsDevice, 100, 100);
            // blurSprite2 = new RenderTarget2D(_graphics.GraphicsDevice, 100, 100);
            // sprite = Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            // effect = Content.Load<Effect>("Shaders/TransitionScene");

            base.Initialize();
        }

        protected override void LoadContent() => _spriteBatch = new SpriteBatch(GraphicsDevice);

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _gameManagement.Update(gameTime);

            base.Update(gameTime);
        }

        // private RenderTarget2D blurSprite;
        // private RenderTarget2D blurSprite2;
        // private Texture2D sprite;
        // private Effect effect;

        protected override void Draw(GameTime gameTime)
        {
            // effect.Parameters["pixel"].SetValue(0.05f);
            // GraphicsDevice.SetRenderTarget(blurSprite);
            // GraphicsDevice.Clear(Color.Black);
            // _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            // _spriteBatch.Draw(sprite, Vector2.Zero, Color.White);
            // _spriteBatch.End();

            // GraphicsDevice.SetRenderTarget(blurSprite2);
            // _spriteBatch.Begin(samplerState: SamplerState.PointClamp, effect: effect);
            // _spriteBatch.Draw(blurSprite, Vector2.Zero, Color.White);
            // _spriteBatch.End();

            // GraphicsDevice.SetRenderTarget(null);
            // GraphicsDevice.Clear(Color.Black);
            // _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            // _spriteBatch.Draw(blurSprite2, Vector2.Zero, null, Color.White, 0, Vector2.Zero, 5f, SpriteEffects.None, 0);
            // _spriteBatch.End();

            _gameManagement.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
