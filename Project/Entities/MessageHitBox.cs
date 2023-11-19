using Project.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Entities
{
    public class MessageHitBox : HitBox
    {
        public override void Start()
        {
            base.Start();

            OnInterectiveCommands.Add(new ShowTextBoxCommand((string)Values[0].Value, Scene));
            OnFinishInterectiveCommands.Add(new ClearAllTextBoxCommand(Scene));
        }
    }
}
