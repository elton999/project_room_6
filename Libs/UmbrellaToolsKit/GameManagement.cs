﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace UmbrellaToolsKit
{
    public class GameManagement : GameObject
    {
        public static event Action OnGameUpdateData;

        public Dictionary<string, object> Values = new Dictionary<string, object>();

        public enum Status { LOADING, CREDITS, MENU, PAUSE, STOP, PLAYING };
        public Status CurrentStatus;

        public enum GameplayStatus { ALIVE, DEATH, };
        public GameplayStatus CurrentGameplayStatus;

        public SceneManagement SceneManagement;
        public Game Game;

        public override void Start()
        {
            this.CurrentStatus = Status.PLAYING;
            this.SceneManagement = new SceneManagement();
            this.SceneManagement.GameManagement = this;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            SceneManagement.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SceneManagement.Draw(spriteBatch);
            OnGameUpdateData?.Invoke();
        }
    }
}
