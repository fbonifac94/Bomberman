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
        // private static List<Rectangle> framesPlayerOne;

        private BombermanPlayerOne(/*List<Rectangle> frames*/ Rectangle frames): base(frames)
        {
        }

        public static BombermanPlayerOne getInstance()
        {
            if (bomberManPlayerOne == null)
            {
             //   framesPlayerOne = new List<Rectangle>();
             //   framesPlayerOne.Add(new Rectangle(0, 0, 50, 50));
                BombermanPlayerOne.bomberManPlayerOne = new BombermanPlayerOne(new Rectangle(85, 65, 40, 30) /* BombermanPlayerOne.framesPlayerOne */);
            }
            return BombermanPlayerOne.bomberManPlayerOne;
        }

    }
}
