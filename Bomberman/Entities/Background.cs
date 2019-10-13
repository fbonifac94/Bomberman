using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
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
        private static List<InvisibleBlock> listBlocks;
        private static Keys key;
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

        public Boolean intersectBlocks(Rectangle sprite)
        {
            return listBlocks.Count(elem => elem.intersect(sprite)) > 0;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(GameTime gameTime)
        {
                base.Draw(gameTime);
                listBlocks = new List<InvisibleBlock>();
                listBlocks.Add(new InvisibleBlock(new Rectangle(20, 20, 750, 40)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(20, 420, 750, 40)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(20, 62, 60, 358)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(710, 62, 60, 358)));

                listBlocks.Add(new InvisibleBlock(new Rectangle(139, 102, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(256, 102, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(369, 102, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(487, 102, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(601, 102, 52, 36)));

                listBlocks.Add(new InvisibleBlock(new Rectangle(139, 181, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(256, 181, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(369, 181, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(487, 181, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(601, 181, 52, 36)));

                listBlocks.Add(new InvisibleBlock(new Rectangle(139, 260, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(256, 260, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(369, 260, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(487, 260, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(601, 260, 52, 36)));

                listBlocks.Add(new InvisibleBlock(new Rectangle(139, 339, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(256, 339, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(369, 339, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(487, 339, 52, 36)));
                listBlocks.Add(new InvisibleBlock(new Rectangle(601, 339, 52, 36)));
                foreach (InvisibleBlock block in listBlocks)
                {
                    block.Draw(gameTime);
                }
              }
            
        }
}
