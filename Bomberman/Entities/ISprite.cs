using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    interface ISprite
    {
        void Draw(GameTime gameTime);

        void Update(GameTime gameTime);
    }
}
