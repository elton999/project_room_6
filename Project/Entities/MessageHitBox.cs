using Project.Commands;

namespace Project.Entities
{
    public class MessageHitBox : HitBox
    {
        public override void Start()
        {
            base.Start();

            OnInteractiveCommands.Add(new ShowTextBoxCommand((string)Values[0].Value, Scene));
            OnFinishInteractiveCommands.Add(new ClearAllTextBoxCommand(Scene));
        }
    }
}
