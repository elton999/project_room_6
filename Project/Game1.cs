using UmbrellaToolsKit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Input;

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
            _gameManagement.SceneManagement.MainScene.SetBackgroundColor = Color.Black;

            KeyBoardHandler.AddInput("interect", Keys.Enter);
            KeyBoardHandler.AddInput("exit", Keys.Escape);

            base.Initialize();
        }

        protected override void LoadContent() => _spriteBatch = new SpriteBatch(GraphicsDevice);

        protected override void Update(GameTime gameTime)
        {
            if (KeyBoardHandler.KeyPressed("exit"))
                Exit();

            _gameManagement.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _gameManagement.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
