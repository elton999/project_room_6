using UmbrellaToolsKit;
using UmbrellaToolsKit.Sprite;
using UmbrellaToolsKit.Collision;

namespace Project.Entities
{
    public class Door : Actor
    {
        public override void Start()
        {
            base.Start();
            Scene.AllActors.Add(this);
        }
    }
}