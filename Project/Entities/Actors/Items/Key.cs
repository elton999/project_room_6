namespace Project.Entities.Actors.Items
{
    public class Key : Item
    {
        public override void Start()
        {
            base.Start();
            tag = "Key";
            size = Atlas.Slices["key"][0].Size;
            Body = Atlas.Slices["key"][0];
        }
    }
}