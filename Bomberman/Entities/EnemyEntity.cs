using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Bomberman.Entities
{
    abstract class EnemyEntity : Sprite
    {
        private Dictionary<Keys, int> mapKeys;

        private Dictionary<Keys, Dictionary<int, Texture2D>> imagesXDirections;

        private BombermanEntity bomberman;

        private TimeSpan tiempo;

        private int currentImage;

        public static String imageRoute = "Shared/Images/Enemy/";

        private Keys currentKey;
        
        public EnemyEntity(Rectangle rectangle) : base(imageRoute + "Down/1", rectangle)
        {
            int speed = 1;

            mapKeys = new Dictionary<Keys, int>();

            mapKeys.Add(Keys.Up, -speed);
            mapKeys.Add(Keys.Down, speed);
            mapKeys.Add(Keys.Right, speed);
            mapKeys.Add(Keys.Left, -speed);

            imagesXDirections = new Dictionary<Keys, Dictionary<int, Texture2D>>();
            imagesXDirections.Add(Keys.Up, base.buildImagesRoutes(imageRoute + "Up/"));
            imagesXDirections.Add(Keys.Down, base.buildImagesRoutes(imageRoute + "Down/"));
            imagesXDirections.Add(Keys.Left, base.buildImagesRoutes(imageRoute + "Left/"));
            imagesXDirections.Add(Keys.Right, base.buildImagesRoutes(imageRoute + "Right/"));

            bomberman = BombermanPlayerOne.getInstance();
        }

        public override void Update(GameTime gameTime)
        {
            bool putBombY = this.modifyEnemyPositionY(gameTime);
            bool putBombX = this.modifyEnemyPositionX(gameTime);

            if (putBombY || putBombX || bomberman.intersect(this.currentFrame))
            {
                createBomb(gameTime);
            }
            changeFocus(gameTime);
        }

        private void changeFocus(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(BombermanGame.lastDieTime).Seconds > 30)
            {
                BombermanGame.lastDieTime = gameTime.TotalGameTime;
                if (bomberman is BombermanPlayerOne)
                {
                    bomberman = BombermanPlayerTwo.getInstance();
                }
                else
                {
                    bomberman = BombermanPlayerOne.getInstance();
                }
            }
        }

        private bool modifyEnemyPositionX(GameTime gametime)
        {
            int xPosition = currentFrame.X;
            int poscToGoX = bomberman.getCurrentPosition().X;

            if (xPosition != poscToGoX)
            {
                if (xPosition < poscToGoX)
                {
                    xPosition += mapKeys[Keys.Right];
                    currentKey = Keys.Right;
                }
                else
                {
                    xPosition += mapKeys[Keys.Left];
                    currentKey = Keys.Left;
                }

                return intersectActions(gametime,
                    new Rectangle(xPosition, currentFrame.Y, currentFrame.Width, currentFrame.Height));
            }
            return false;
        }


        private bool modifyEnemyPositionY(GameTime gametime)
        {
            int yPosition = currentFrame.Y;
            int poscToGoY = bomberman.getCurrentPosition().Y;

            if (yPosition != poscToGoY)
            {
                if (yPosition > poscToGoY)
                {
                    yPosition += mapKeys[Keys.Up];
                    currentKey = Keys.Up;
                }
                else
                {
                    yPosition += mapKeys[Keys.Down];
                    currentKey = Keys.Down;
                }
                return intersectActions(gametime, 
                    new Rectangle(currentFrame.X, yPosition, currentFrame.Width, currentFrame.Height));
            }
            return false;
        }

        private bool intersectActions(GameTime gameTime, Rectangle newPosition)
        {
            if (!Background.getInstance().intersectBlocks(newPosition))
            {
                updateImage(gameTime, currentKey);
                currentFrame = newPosition;
            }
            else
            {
                if (Background.getInstance().intersectSolidBlocks(newPosition))
                {
                    return true;
                }
            }
            return false;
        }


        private void createBomb(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(tiempo).Milliseconds > 500)
            {
                tiempo = gameTime.TotalGameTime;
                Bomb bomb = new Bomb(new Rectangle(base.currentFrame.X, base.currentFrame.Y, base.currentFrame.Width, base.currentFrame.Height), gameTime.TotalGameTime);
                if (!Background.getInstance().intersectBombs(bomb.getCurrentPosition()))
                {
                    Background.getInstance().addBombs(bomb);
                }
            }
        }

        private void updateImage(GameTime gameTime, Keys key)
        {
            int sleepTime = 80;

            if (gameTime.TotalGameTime.Subtract(tiempo).Milliseconds > sleepTime)
            {

                if (!this.currentKey.Equals(key))
                {
                    this.currentKey = key;
                    this.currentImage = 0;
                }
                this.currentImage = (this.currentImage == this.imagesXDirections[key].Count - 1) ? 0 : this.currentImage + 1;
                base.image = this.imagesXDirections[key][this.currentImage];
            }
        }
    }
}
