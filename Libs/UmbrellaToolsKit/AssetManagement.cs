using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit
{
    public struct AssetObject
    {
        public string Layer;
        public string Name;
        public Vector2 Position;
        public Type GameObject;
    }

    public class AssetManagement
    {
        public static AssetManagement Instance;
        public List<AssetObject> AssetsList = new List<AssetObject>();
        public List<AssetObject> LevelAssetsList = new List<AssetObject>();

        public AssetManagement() => Instance = this;

        public void Set<T>(string tag, string layer) where T : GameObject
        {
            AssetObject assetObject = new AssetObject { Name = tag, Layer = layer, GameObject = typeof(T) };
            this.AssetsList.Add(assetObject);
        }

        public GameObject GetObject(string name)
        {
            IEnumerable<AssetObject> assetObjects = this.AssetsList.Where(asset => asset.Name == name);

            if (assetObjects.Count() > 0)
            {
                AssetObject assetObject = assetObjects.First();
                GameObject gameObject = (GameObject)Activator.CreateInstance(assetObject.GameObject);

                return gameObject;
            }

            return new GameObject();
        }

        public string GetLayer(string name)
        {
            IEnumerable<AssetObject> assetObjects = this.AssetsList.Where(asset => asset.Name == name);
            if (assetObjects.Count() > 0)
                return assetObjects.ToList()[0].Layer;
            return "";
        }

        public GameObject addEntityOnScene(string name, string tag, Vector2 position, Point size, dynamic values, List<Vector2> nodes, Scene scene)
        { // ? values:Dynamic, ? nodes:Array<Vector2>, ? flipx:Bool):Void{
            var gameObject = SetGameObjectInfos(name, tag, position, size, values, nodes, scene);

            string layer = GetLayer(name);
            SetLayer(scene, gameObject, layer);

            gameObject.Start();
            return gameObject;
        }

        public GameObject SetGameObjectInfos(string name, string tag, Vector2 position, Point size, dynamic values, List<Vector2> nodes, Scene scene)
        {
            GameObject gameObject = GetObject(name);

            gameObject.tag = tag;
            gameObject.Position = position;
            gameObject.size = size;
            gameObject.Values = values;
            gameObject.Nodes = nodes;
            gameObject.Content = scene.Content;
            gameObject.Scene = scene;

            return gameObject;
        }

        public static void SetLayer(Scene scene, GameObject gameObject, string layer)
        {
            if (layer == "PLAYER")
                scene.Players.Add(gameObject);
            else if (layer == "ENEMIES")
                scene.Enemies.Add(gameObject);
            else if (layer == "FOREGROUND")
                scene.Foreground.Add(gameObject);
            else if (layer == "MIDDLEGROUND")
                scene.Middleground.Add(gameObject);
            else if (layer == "BACKGROUND")
                scene.Backgrounds.Add(gameObject);
        }

        public void ClearAll() => LevelAssetsList.Clear();
    }
}
