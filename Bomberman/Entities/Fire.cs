using System;
using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    class Fire : TimedSprite
    {
        public Fire(Rectangle rectangle, TimeSpan gameTime) : base("Shared/Images/fire", rectangle)
        {
            this.tiempo = gameTime;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override Boolean isTimeForDelete(GameTime gameTime)
        {
            return gameTime.TotalGameTime.Subtract(tiempo).Milliseconds > 300;
        }
    }
}
