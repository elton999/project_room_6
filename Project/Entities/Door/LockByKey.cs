﻿using Project.Nodes;
using Project.Entities;
using Project.Interfaces;
using Project.GamePlay.Nodes.Puzzle;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Project.Entities.Actors.Items.Nodes;

namespace Project
{
    public class LockByKey : Actor, IDoor
    {
        private string _itemToOpenDoor;

        public Door Door { get; set; }

        public override void Start()
        {
            base.Start();

            _itemToOpenDoor = GetKeyName();

            System.Console.WriteLine($"item name: {_itemToOpenDoor}");

            Node = new SequenceNode();
            Node.CreateData();
            Node.AddData("targetPlayer", Scene.Players[0]);

            Node.Add(new SearchDoorNode(this, this));

            var OpenDoorSequence = new SequenceNode();
            OpenDoorSequence.Add(new CheckingActorOverActorNode(this, Scene.AllActors[0]));
            OpenDoorSequence.Add(new CheckingIfHasItemNode(_itemToOpenDoor));
            OpenDoorSequence.Add(new UseItemFromInventoryNode(_itemToOpenDoor));
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
