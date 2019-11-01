using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    abstract class Block: Sprite
    {
        public Block(string img, Rectangle frame) : base(img, frame) { }
    }
}
