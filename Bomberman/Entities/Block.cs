using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    class InvisibleBlock : Sprite
    {
        public InvisibleBlock(Rectangle frames) : base("Shared/Images/transparente", frames) { }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
