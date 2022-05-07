using UmbrellaToolsKit.Sprite;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities.Player.State;

namespace Project.Entities.Player
{
    public class Player : Actor
    {
        public AsepriteAnimation Animation;
        public PlayerState CurrentState;

        public float Speed = 0.25f;
        public float SpeedDash = 4.5f;

        public override void Start()
        {
            Gravity2D = Vector2.Zero;

            Animation = new AsepriteAnimation(Content.Load<AsepriteDefinitions>("Sprites/Player/player_animation"));
            Sprite = Content.Load<Texture2D>("Sprites/Player/player");
            size = new Point(16, 16);
            Origin = new Vector2(24, 35);

            CurrentState = new PlayerStateIdle(this);

            Scene.AllActors.Add(this);
            base.Start();
        }

        public void SwitchState(PlayerState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }

        public override void Update(GameTime gametime)
        {
            Body = Animation.Body;

            CurrentState.InputUpdate(gametime);
            CurrentState.LogicUpdate(gametime);

            Scene.Camera.Target = Position;
        }

        public override void UpdateData(GameTime gametime)
        {
            CurrentState.PhysicsUpdate(gametime);
            base.UpdateData(gametime);
        }
    }
}
