using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomberman.Entities
{
    class Background : Sprite
    {
        private static Background background;
        private List<InvisibleBlock> invisibleListBlocks;
        private List<SolidBlock> solidListBlocks;
        private List<Block> listBlocks;
        private List<Bomb> bombs;
        private List<Fire> fires;
        private static Keys key;
        private bool initializedInvisible;
        private bool initializedSolid;

        private Background(Rectangle frames) : base("Shared/Images/map", frames) {
            this.bombs = new List<Bomb>();
            this.fires = new List<Fire>();
            this.listBlocks = new List<Block>();
        }

        public static Background getInstance(bool requireNewInstance = false)
        {
            if (Background.background == null || requireNewInstance)
            {
                Background.background = new Background(new Rectangle(0, 0, BombermanGame.getInstance().GraphicsDevice.Viewport.Width, BombermanGame.getInstance().GraphicsDevice.Viewport.Height));
            }
            return Background.background;
        }

        public Boolean intersectBlocks(Rectangle sprite)
        {
            return listBlocks.Count(elem => elem.intersect(sprite)) > 0;
        }

        public Boolean intersectInvisibleBlocks(Rectangle sprite)
        {
            return invisibleListBlocks.Count(elem => elem.intersect(sprite)) > 0;
        }

        public void destroySolidBlocks(Rectangle sprite)
        {
            for (int i = 0; i < solidListBlocks.Count; i++)
            {
                if (solidListBlocks[i].intersect(sprite))
                {
                    solidListBlocks.RemoveAt(i);
                    this.listBlocks = new List<Block>();
                    listBlocks.AddRange(this.invisibleListBlocks);
                    listBlocks.AddRange(this.solidListBlocks);
                }
            }
        }

        public void addBombs(Bomb bomb) {
            this.bombs.Add(bomb);
        }

        public override void Update(GameTime gameTime)
        {
            if (bombs.Count() > 0) {
                for (int i = 0; i < bombs.Count(); i++) {
                    if (bombs[i].isTimeForDelete(gameTime))
                    {
                        Bomb bomb = bombs[i];
                        bombs.RemoveAt(i);
                        buildFire(bomb, gameTime);
                        return;
                    }
                }
            }
            if (fires.Count() > 0)
            {
                for (int i = 0; i < fires.Count(); i++)
                {
                    destroySolidBlocks(fires[i].getCurrentPosition());
                    if (fires[i].isTimeForDelete(gameTime))
                    {
                        fires.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if (!initializedInvisible) { buildInvisibleBlocks(); }
            if (!initializedSolid) { buildSolidBlocks(); }

            foreach (Block block in listBlocks)
            {
                block.Draw(gameTime);
            }

            foreach (Bomb bomb in bombs) {
                bomb.Draw(gameTime);
            }

            foreach (Fire fire in fires)
            {
                fire.Draw(gameTime);
            }
        }

        private void buildSolidBlocks()
        {
            solidListBlocks = new List<SolidBlock>();
            solidListBlocks.Add(new SolidBlock(new Rectangle(85, 103, 52, 35)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(85, 139, 52, 40)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(255, 65, 52, 36)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(197, 103, 57, 35)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(255, 142, 52, 36)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(308, 142, 58, 36)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(195, 181, 60, 36)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(256, 222, 52, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(310, 222, 57, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(311, 180, 54, 40)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(257, 302, 52, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(198, 302, 58, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(140, 302, 56, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(85, 302, 54, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(85, 262, 52, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(85, 220, 52, 40)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(198, 380, 54, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(311, 380, 54, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(369, 380, 56, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(428, 380, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(428, 340, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(428, 300, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(428, 102, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(428, 62, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(428, 142, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(485, 222, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(485, 62, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(485, 302, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(542, 262, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(542, 342, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(600, 382, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(656, 262, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(656, 222, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(656, 182, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(542, 142, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(600, 142, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(542, 182, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(600, 64, 55, 38)));
            solidListBlocks.Add(new SolidBlock(new Rectangle(656, 64, 55, 38)));
            listBlocks.AddRange(solidListBlocks);
            initializedSolid = true;
        }

        private void buildInvisibleBlocks()
        {
            invisibleListBlocks = new List<InvisibleBlock>();
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(20, 20, 750, 40)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(20, 420, 750, 40)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(20, 62, 60, 358)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(710, 62, 60, 358)));

            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(139, 102, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(256, 102, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(369, 102, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(487, 102, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(601, 102, 52, 36)));

            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(139, 181, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(256, 181, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(369, 181, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(487, 181, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(601, 181, 52, 36)));

            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(139, 260, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(256, 260, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(369, 260, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(487, 260, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(601, 260, 52, 36)));

            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(139, 339, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(256, 339, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(369, 339, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(487, 339, 52, 36)));
            invisibleListBlocks.Add(new InvisibleBlock(new Rectangle(601, 339, 52, 36)));

            listBlocks.AddRange(invisibleListBlocks);
            initializedInvisible = true;
        }


        private void buildFire(Bomb bomb, GameTime gameTime)
        {
            Rectangle actualPosition = bomb.getCurrentPosition();
            Rectangle topPosition = new Rectangle(actualPosition.X, actualPosition.Y - actualPosition.Height, actualPosition.Width, actualPosition.Height);
            Rectangle botPosition = new Rectangle(actualPosition.X, actualPosition.Y + actualPosition.Height, actualPosition.Width, actualPosition.Height);
            Rectangle leftPosition = new Rectangle(actualPosition.X - actualPosition.Width, actualPosition.Y, actualPosition.Width, actualPosition.Height);
            Rectangle rightPosition = new Rectangle(actualPosition.X + actualPosition.Width, actualPosition.Y, actualPosition.Width, actualPosition.Height);
            fires.Add(new Fire(actualPosition, gameTime.TotalGameTime));
            if (!this.intersectInvisibleBlocks(topPosition)) { fires.Add(new Fire(topPosition, gameTime.TotalGameTime)); }
            if (!this.intersectInvisibleBlocks(botPosition)) { fires.Add(new Fire(botPosition, gameTime.TotalGameTime)); }
            if (!this.intersectInvisibleBlocks(leftPosition)) { fires.Add(new Fire(leftPosition, gameTime.TotalGameTime)); }
            if (!this.intersectInvisibleBlocks(rightPosition)) { fires.Add(new Fire(rightPosition, gameTime.TotalGameTime)); }

        }

        public Boolean fireIntersectSomething(Rectangle rectangle)
        {
            return fires.Count(elem => elem.intersect(rectangle)) > 0;
        }
    }
}
