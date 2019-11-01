using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    abstract class TimedSprite : Sprite
    {   protected TimeSpan tiempo { get; set; }

        protected TimedSprite(string img, Rectangle rectangle) : base(img, rectangle){}

        public virtual Boolean isTimeForDelete(GameTime gameTime)
        {
            return gameTime.TotalGameTime.Subtract(tiempo).Seconds > 2;
        }

    }

}
