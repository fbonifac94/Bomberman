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
    abstract class BombermanEntity : Sprite
    {
        private Dictionary<Keys, int> mapKeys;

        private Dictionary<Keys, Dictionary<int, Texture2D>> imagesXDirections;

        public static String imageRoute = "Shared/Images/Bomberman/";

        private TimeSpan tiempo;

        private static int currentImage;

        private static Keys currentKey;

        public BombermanEntity() { }

        public BombermanEntity(Rectangle rectangle) : base(imageRoute + "Down/1", rectangle)
        {
            int speed = 2;
            mapKeys = new Dictionary<Keys, int>();
            mapKeys.Add(Keys.Up, -speed);
            mapKeys.Add(Keys.Down, speed);
            mapKeys.Add(Keys.Right, speed);
            mapKeys.Add(Keys.Left, -speed);

            imagesXDirections = new Dictionary<Keys, Dictionary<int, Texture2D>>();
            imagesXDirections.Add(Keys.Up, this.buildImagesRoutes(imageRoute + "Up/"));
            imagesXDirections.Add(Keys.Down, this.buildImagesRoutes(imageRoute + "Down/"));
            imagesXDirections.Add(Keys.Left, this.buildImagesRoutes(imageRoute + "Left/"));
            imagesXDirections.Add(Keys.Right, this.buildImagesRoutes(imageRoute + "Right/"));

        }

        public Dictionary<int, Texture2D> buildImagesRoutes(String route) {
            Dictionary<int, Texture2D> images = new Dictionary<int, Texture2D>();
            DirectoryInfo filesRoute = new DirectoryInfo("Content/" + route);
            FileInfo[] files = filesRoute.GetFiles("*");
            for (int i = 0; i < files.Count(); i++) {
                images.Add(i, BombermanGame.getInstance().Content.Load<Texture2D>(route + files[i].Name.Replace(".xnb", "")));
            }
            return images;
        }

        private void updateImage(GameTime gameTime, Keys key)
        {
            int sleepTime = 80;

            if (gameTime.TotalGameTime.Subtract(tiempo).Milliseconds > sleepTime)
            {

                if (!BombermanEntity.currentKey.Equals(key))
                {
                    BombermanEntity.currentKey = key;
                    BombermanEntity.currentImage = 0;
                }
                BombermanEntity.currentImage = (BombermanEntity.currentImage == this.imagesXDirections[key].Count - 1) ? 0 : BombermanEntity.currentImage + 1;
                base.image = this.imagesXDirections[key][BombermanEntity.currentImage];
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                updateImage(gameTime, Keys.Up);
                this.modifyBombermanPosition(Keys.Up);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                updateImage(gameTime, Keys.Down);
                this.modifyBombermanPosition(Keys.Down);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                updateImage(gameTime, Keys.Left);
                this.modifyBombermanPosition(Keys.Left);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                updateImage(gameTime, Keys.Right);
                this.modifyBombermanPosition(Keys.Right);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                new Bomb(new Rectangle(base.currentFrame.X, base.currentFrame.Y, base.currentFrame.Width, base.currentFrame.Height).);
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

            Rectangle newPosc = new Rectangle(xPosition, yPosition, currentFrame.Width, currentFrame.Height);

            if (!Background.getInstance().intersectBlocks(newPosc))
            {
                currentFrame = newPosc;
            }
        }
    }
}
