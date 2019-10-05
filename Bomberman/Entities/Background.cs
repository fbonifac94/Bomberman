using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    class Background : Sprite
    {
        private static Background background;
        // private static List<Rectangle> framesBackground;

        private Background(/* List<Rectangle> frames*/ Rectangle frames) : base("Shared/Images/map", frames) { }

        public static Background getInstance()
        {
            if (Background.background == null)
            {
                // framesBackground = new List<Rectangle>();
                // framesBackground.Add(new Rectangle(0, 0, BombermanGame.getInstance().GraphicsDevice.Viewport.Width, BombermanGame.getInstance().GraphicsDevice.Viewport.Height));
                Background.background = new Background(new Rectangle(0, 0, BombermanGame.getInstance().GraphicsDevice.Viewport.Width, BombermanGame.getInstance().GraphicsDevice.Viewport.Height));
            }
            return Background.background;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            List<Block> listBlocks = new List<Block>();
            listBlocks.Add(new Block(new Rectangle(20, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(80, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(140, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(200, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(260, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(320, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(380, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(440, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(500, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(560, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(620, 20, 60, 40)));
            listBlocks.Add(new Block(new Rectangle(680, 20, 60, 40)));
            foreach (Block block in listBlocks)
            {
                block.Draw(gameTime);
            }
        }
    }
}
