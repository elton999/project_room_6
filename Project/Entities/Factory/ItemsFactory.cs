using Project.Entities.Actors.Items;

namespace Project.Entities.Factory
{
    public class ItemsFactory
    {
        public Actors.Items.Item MakeKeyGameObject() { return new Key(); }
    }
}
