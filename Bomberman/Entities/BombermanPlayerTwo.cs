using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Bomberman.Entities
{
    class BombermanPlayerTwo: BombermanEntity
    {
        private static BombermanPlayerTwo bomberManPlayerTwo;

        private BombermanPlayerTwo(Rectangle frames) : base(new Vector2(670, 8), Color.Black, "Player Two", frames, new Controllers(Keys.NumPad8, Keys.NumPad2, Keys.NumPad4, Keys.NumPad6, Keys.NumPad0)) { }

        public static BombermanPlayerTwo getInstance(bool requireNewInstance = false)
        {
            if (bomberManPlayerTwo == null || requireNewInstance)
            {
                BombermanPlayerTwo.bomberManPlayerTwo = new BombermanPlayerTwo(new Rectangle(670, 380, 40, 35));
            }
            return BombermanPlayerTwo.bomberManPlayerTwo;
        }
    }
}
