using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman.Entities
{
    public abstract class Sprite: ISprite
    {
        protected Texture2D image { get; set; }
        // protected Dictionary<int, Rectangle> frames { get; set; }
        // protected int poscCurrentFrame { get; set; }
        protected Rectangle currentFrame { get; set; }

        public Sprite() { }
        
        public Sprite(String imagePath, Rectangle currentFrame /* List<Rectangle> listframes */)
        {
            // this.poscCurrentFrame = 0;
            this.image = BombermanGame.getInstance().Content.Load<Texture2D>(imagePath);
            // frames = new Dictionary<int, Rectangle>();
            /* int index = 0;
            foreach (Rectangle frame in listframes)
            {
                frames.Add(index, frame);
                index++;
            }
            index = 0; */
            this.currentFrame = currentFrame;//frames[poscCurrentFrame];
        }

        public virtual void Draw(GameTime gameTime)
        {
            BombermanGame.getInstance().spriteBatch.Draw(image, this.currentFrame, Color.White);
        }

        public abstract void Update(GameTime gameTime);

        public Boolean intersect(Rectangle sprite) {
            return this.currentFrame.Intersects(sprite);
        }
    }
}
