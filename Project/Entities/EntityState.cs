using Microsoft.Xna.Framework;

namespace Project.Entities
{
    public abstract class EntityState
    {
        public virtual void Enter() { }
        public virtual void LogicUpdate(GameTime gametime) { }
        public virtual void PhysicsUpdate(GameTime gametime) { }
        public virtual void Exit() { }
    }
}