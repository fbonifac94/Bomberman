﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    class Bomb : TimedSprite
    {
        public Bomb(Rectangle rectangle, TimeSpan gameTime): base("Shared/Images/bomb", rectangle)
        {
            this.tiempo = gameTime;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
