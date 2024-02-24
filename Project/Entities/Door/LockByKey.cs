using Project.Nodes;
using Project.Entities;
using Project.Interfaces;
using Project.GamePlay.Nodes.Puzzle;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Project.Entities.Actors.Items.Nodes;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit.Sprite;

namespace Project
{
    public class LockByKey : Actor, IDoor
    {
        private string _itemToOpenDoor;
        private GameObject _lockSpriteGameObject;

        public Door Door { get; set; }

        public override void Start()
        {
            base.Start();

            AddSprite();
            AddAiLogic();
        }

        private void AddSprite()
        {
            _lockSpriteGameObject = new GameObject();

            _lockSpriteGameObject.Sprite = Scene.Content.Load<Texture2D>(FilePath.SPRITE_PATH);
            AsepriteDefinitions atlas = Scene.Content.Load<AsepriteDefinitions>(FilePath.SPRITE_ATLAS_PATH);

            _lockSpriteGameObject.size = atlas.Slices["key"].Item1.Size;
            _lockSpriteGameObject.Body = atlas.Slices["lock_key"].Item1;

            _lockSpriteGameObject.Position = Position + size.ToVector2() / 2f;
            _lockSpriteGameObject.Origin = _lockSpriteGameObject.size.ToVector2() / 2f;

            _lockSpriteGameObject.Scene = Scene;
            Scene.Middleground.Add(_lockSpriteGameObject);
        }

        private void AddAiLogic()
        {
            _itemToOpenDoor = GetKeyName();

            Node = new SequenceNode();
            Node.CreateData();
            Node.AddData("targetPlayer", Scene.Players[0]);

            Node.Add(new SearchDoorNode(this, this));

            var OpenDoorSequence = new SequenceNode();
            OpenDoorSequence.Add(new CheckingActorOverActorNode(this, Scene.AllActors[0]));
            OpenDoorSequence.Add(new CheckingIfHasItemNode(_itemToOpenDoor));
            OpenDoorSequence.Add(new UseItemFromInventoryNode(_itemToOpenDoor));
            OpenDoorSequence.Add(new RemoveGameObjectFromScene(_lockSpriteGameObject));
            OpenDoorSequence.Add(new SwitchCameraTargetNode("targetDoor"));
            OpenDoorSequence.Add(new DelayNode(new OpenDoorNode(this), 0.5f));
            OpenDoorSequence.Add(new DelayNode(new SwitchCameraTargetNode("targetPlayer"), 0.5f));
            Node.Add(new InverterNode(OpenDoorSequence));

            Node.Add(new CloseDoorNode(this));
        }

        private string GetKeyName()
        {
            ldtk.FieldInstance[] fields = Values;
            for (int i = 0; i < fields.Length; i++)
                if (fields[i].Identifier.ToLower() == "key")
                    return (string)fields[i].Value;
            return "";
        }
    }
}
