using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Bomberman.Entities
{
    class BombermanPlayerOne : BombermanEntity
    {
        private static BombermanPlayerOne bomberManPlayerOne;

        private BombermanPlayerOne(Rectangle frames): base(new Vector2(25, 8), Color.Red, "Player One", frames, new Controllers(Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space)) {}

        public static BombermanPlayerOne getInstance(bool requireNewInstance = false)
        {
            if (bomberManPlayerOne == null || requireNewInstance)
            {
                BombermanPlayerOne.bomberManPlayerOne = new BombermanPlayerOne(new Rectangle(85, 65, 40, 35));
            }
            return BombermanPlayerOne.bomberManPlayerOne;
        }
    }
}
