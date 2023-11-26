using Microsoft.Xna.Framework;

namespace Project.Entities.Factory
{
    public class CharacterFactory
    {
        public CharacterRender MakeOldManCharacter()
        {
            return new CharacterRender(new Rectangle(39, 18, 14, 30));
        }

        public CharacterRender MakeAsianGuyCharacter()
        {
            return new CharacterRender(new Rectangle(103, 16, 15, 32));
        }
    }
}
