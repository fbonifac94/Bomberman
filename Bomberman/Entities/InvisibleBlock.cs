using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    class InvisibleBlock : Block
    {
        public InvisibleBlock(Rectangle frames) : base("Shared/Images/transparente", frames) { }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
