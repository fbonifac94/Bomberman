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
        protected Rectangle currentFrame { get; set; }

        public Sprite() { }
        
        public Sprite(String imagePath, Rectangle currentFrame)
        {
            this.image = BombermanGame.getInstance().Content.Load<Texture2D>(imagePath);
            this.currentFrame = currentFrame;
        }

        public virtual void Draw(GameTime gameTime)
        {
            BombermanGame.getInstance().spriteBatch.Draw(image, this.currentFrame, Color.White);
        }

        public abstract void Update(GameTime gameTime);

        public Boolean intersect(Rectangle sprite) {
            return this.currentFrame.Intersects(sprite);
        }

        public Rectangle getCurrentPosition()
        {
            return this.currentFrame;
        }
    }
}
