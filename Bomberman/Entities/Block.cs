using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    class Block : Sprite
    {
        public Block(Rectangle frames) : base("Shared/Images/block", frames) { }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
