using Project.Commands;
using Project.Nodes;

namespace Project.Entities
{
    public class MessageHitBox : HitBox
    {
        public override void Start()
        {
            base.Start();

            OnInteractiveCommands.Add(new ShowTextBoxCommand((string)Values[0].Value, Scene));
            OnInteractiveNodes.Add(new LockPlayerMovementsNode());

            OnFinishInteractiveCommands.Add(new ClearAllTextBoxCommand(Scene));
            OnFinishInteractiveNodes.Add(new UnlockPlayerMovementsNode());
        }
    }
}
