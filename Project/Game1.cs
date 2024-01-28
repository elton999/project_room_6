using UmbrellaToolsKit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Input;
using Project.CutScenes;

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
            _assetManagement.Set<Entities.Actors.Items.SpawnItemInventory>("Player", "FOREGROUND");
            _assetManagement.Set<Entities.Door>("Door", "MIDDLEGROUND");
            _assetManagement.Set<GameObject>("PlayerSpawn", "MIDDLEGROUND");

            _assetManagement.Set<Entities.Solids.Box>("Box", "MIDDLEGROUND");
            _assetManagement.Set<Entities.Solids.SolidBox>("SolidBlock", "MIDDLEGROUND");
            _assetManagement.Set<Entities.Actors.GroundButton>("GroundButton", "BACKGROUND");
            _assetManagement.Set<Entities.Actors.Items.ItemInstance>("Item", "FOREGROUND");
            _assetManagement.Set<Entities.Document>("Document", "MIDDLEGROUND");

            _assetManagement.Set<Entities.CharacterInstance>("Character", "MIDDLEGROUND");
            _assetManagement.Set<Entities.MessageHitBox>("Message", "MIDDLEGROUND");

            _assetManagement.Set<GamePlay.PuzzleButtons>("PuzzleButtons", "BACKGROUND");
            _assetManagement.Set<Entities.Camera>("Camera", "FOREGROUND");

            _gameManagement.SceneManagement.Start();
            _gameManagement.SceneManagement.MainScene.SetBackgroundColor = Color.Black;

            var initialScene = new InitialSentence() { Scene = _gameManagement.SceneManagement.MainScene };
            _gameManagement.SceneManagement.MainScene.UI.Add(initialScene);
            initialScene.Start();

            // inputs
            KeyBoardHandler.AddInput("interect", new Keys[] { Keys.Enter, Keys.X, Keys.Space });
            KeyBoardHandler.AddInput("exit", Keys.Escape);

            KeyBoardHandler.AddInput("up", new Keys[] { Keys.W, Keys.Up });
            KeyBoardHandler.AddInput("down", new Keys[] { Keys.S, Keys.Down });
            KeyBoardHandler.AddInput("left", new Keys[] { Keys.A, Keys.Left });
            KeyBoardHandler.AddInput("right", new Keys[] { Keys.D, Keys.Right });

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
