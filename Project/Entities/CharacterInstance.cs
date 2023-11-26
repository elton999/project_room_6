using Project.Entities.Factory;
using UmbrellaToolsKit;

namespace Project.Entities
{
    public class CharacterInstance : GameObject
    {
        private CharacterFactory _characterFactory;

        public override void Start()
        {
            _characterFactory = new CharacterFactory();

            GameObject characterGameObject;
            
            switch ((string)Values[0].Value)
            {
                case "OldMan":
                    characterGameObject = _characterFactory.MakeOldManCharacter();
                    break;
                case "AsianGuy":
                    characterGameObject = _characterFactory.MakeAsianGuyCharacter();
                    break;
                default:
                    characterGameObject = new GameObject();
                    break;
            }

            Scene.Middleground.Add(characterGameObject);
            characterGameObject.Scene = Scene;
            characterGameObject.Position = Position;
            characterGameObject.Start();
        }
    }
}
