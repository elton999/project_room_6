using UmbrellaToolsKit;

namespace Project.Entities
{
    public class Camera : GameObject
    {
        public override void Start() => Scene.Camera.UseLevelLimits = false;
    }
}
