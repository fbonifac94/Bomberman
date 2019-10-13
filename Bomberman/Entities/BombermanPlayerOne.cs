using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    class BombermanPlayerOne : BombermanEntity
    {
        private static BombermanPlayerOne bomberManPlayerOne;

        private BombermanPlayerOne(Rectangle frames): base(frames)
        {
        }

        public static BombermanPlayerOne getInstance()
        {
            if (bomberManPlayerOne == null)
            {
                BombermanPlayerOne.bomberManPlayerOne = new BombermanPlayerOne(new Rectangle(85, 65, 40, 40) /* BombermanPlayerOne.framesPlayerOne */);
            }
            return BombermanPlayerOne.bomberManPlayerOne;
        }

    }
}
