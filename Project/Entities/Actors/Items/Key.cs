using Microsoft.Xna.Framework;
using Project.GamePlay;
using System;

namespace Project.Entities.Actors.Items
{
    public class Key : Item
    {
        public override void Start()
        {
            tag = "Key";
            size = new Point(16, 16);
            Body = new Rectangle(new Point(192, 32), new Point(16, 16));
            base.Start();
        }
    }
}