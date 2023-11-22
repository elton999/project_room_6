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

        public List<GameObject> GetObject(string name)
        {
            IEnumerable<AssetObject> assetObjects = this.AssetsList.Where(asset => asset.Name == name);

            if (assetObjects.Count() > 0)
            {
                List<GameObject> objects = new List<GameObject>();
                foreach(AssetObject assetObject in assetObjects)
                {
                    GameObject gameObject = (GameObject)Activator.CreateInstance(assetObject.GameObject);
                    objects.Add(gameObject);
                }

                return objects;
            }

            return new List<GameObject>();
        }

        public string GetLayer(string name)
        {
            IEnumerable<AssetObject> assetObjects = this.AssetsList.Where(asset => asset.Name == name);
            if (assetObjects.Count() > 0)
                return assetObjects.ToList()[0].Layer;
            return "";
        }

        public void addEntityOnScene(string name, string tag, Vector2 position, Point size, dynamic values, List<Vector2> nodes, Scene scene)
        { // ? values:Dynamic, ? nodes:Array<Vector2>, ? flipx:Bool):Void{
            List<GameObject> gameObjects = SetGameObjectInfos(name, tag, position, size, values, nodes, scene);

            foreach(var gameObject in gameObjects)
            {
                string layer = GetLayer(name);
                SetLayer(scene, gameObject, layer);

                gameObject.Start();
            }
        }

        public List<GameObject> SetGameObjectInfos(string name, string tag, Vector2 position, Point size, dynamic values, List<Vector2> nodes, Scene scene)
        {
            List<GameObject> gameObjects = GetObject(name);
            foreach(GameObject gameObject in gameObjects)
            {
                gameObject.tag = tag;
                gameObject.Position = position;
                gameObject.size = size;
                gameObject.Values = values;
                gameObject.Nodes = nodes;
                gameObject.Content = scene.Content;
                gameObject.Scene = scene;
            }
            return gameObjects;
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
