using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Bomberman.Entities
{
    public class Bonus : Sprite
    {
        public static String imageRoute = "Shared/Images/bonus/";

        public Bonus(string img, int x, int y) : base(imageRoute + img, new Rectangle(x, y, 40, 35)) {}

        public override void Update(GameTime gameTime) {}
    }
}
