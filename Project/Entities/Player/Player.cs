using UmbrellaToolsKit.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities.Player.State;
using Project.Nodes;

namespace Project.Entities.Player
{
    public class Player : UmbrellaToolsKit.Collision.Actor
    {
        public AsepriteAnimation Animation;
        public PlayerState CurrentState;

        public float Speed = 0.25f;
        public float SpeedDash = 4.5f;
        public static bool CanMove = true;

        public override void Start()
        {
            Gravity2D = Vector2.Zero;

            Animation = new AsepriteAnimation(Content.Load<AsepriteDefinitions>("Sprites/Player/player_animation"));
            Sprite = Content.Load<Texture2D>("Sprites/Player/player");
            size = new Point(16, 16);
            Origin = new Vector2(24, 35);

            CurrentState = new PlayerStateIdle(this, new Vector2(0, 1f));

            Scene.AllActors.Add(this);
            base.Start();

            Scene.Camera.Target = this;
            if (!Scene.GameManagement.Values.ContainsKey("canPlay"))
                Scene.GameManagement.Values.Add("canPlay", true);

            LockPlayerMovementsNode.OnLockPlayerMovements += LockPlayerMovements;
            UnlockPlayerMovementsNode.OnUnlockPlayerMovements += UnlockPlayerMovements;
        }

        public override void Destroy()
        {
            LockPlayerMovementsNode.OnLockPlayerMovements -= LockPlayerMovements;
            UnlockPlayerMovementsNode.OnUnlockPlayerMovements -= UnlockPlayerMovements;
            base.Destroy();
        }

        public void LockPlayerMovements() => CanMove = false;
        public void UnlockPlayerMovements() => CanMove = true;

        public void SwitchState(PlayerState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }

        public override void Update(GameTime gameTime)
        {
            if (!CanMove) return;
            Body = Animation.Body;

            if (!(bool)Scene.GameManagement.Values["canPlay"])
                return;
            CurrentState.InputUpdate(gameTime);
            CurrentState.LogicUpdate(gameTime);
        }

        public override void UpdateData(GameTime gameTime)
        {
            if (!CanMove) return;
            CurrentState.PhysicsUpdate(gameTime);
            base.UpdateData(gameTime);
        }
    }
}
