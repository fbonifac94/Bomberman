using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Bomberman.Entities
{
    abstract class BombermanEntity : Sprite
    {
        private Dictionary<Keys, int> mapKeys;

        public BombermanEntity() { }

        public BombermanEntity(/*List<Rectangle> listframes*/ Rectangle listframes) : base("Shared/Images/Bomber_1", listframes)
        {
            int speed = 2;
            mapKeys = new Dictionary<Keys, int>();
            mapKeys.Add(Keys.Up, -speed);
            mapKeys.Add(Keys.Down, speed);
            mapKeys.Add(Keys.Right, speed);
            mapKeys.Add(Keys.Left, -speed);

        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.modifyBombermanPosition(Keys.Up);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.modifyBombermanPosition(Keys.Down);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.modifyBombermanPosition(Keys.Left);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.modifyBombermanPosition(Keys.Right);
            }

        }

        private void modifyBombermanPosition(Keys key)
        {
            int xPosition = currentFrame.X;
            int yPosition = currentFrame.Y;
            if (key.Equals(Keys.Up) || key.Equals(Keys.Down))
            {
                yPosition += mapKeys[key];
            }
            else
            {
                xPosition += mapKeys[key];
            }

            currentFrame = new Rectangle(xPosition, yPosition, currentFrame.Width, currentFrame.Height);
        }
    }
}
