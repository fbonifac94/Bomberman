﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        private TimeSpan tiempoBomba;

        private static int currentImage;

        private static Keys currentKey;

        private List<Bomb> bombs;

        private Controllers controller;

        private String player;

        private Color scoreColor;

        private Vector2 scorePosition;

        List<Keys> allKeys;

        public BombermanEntity() { }

        public BombermanEntity(Vector2 scorePosition, Color color, String player, Rectangle rectangle, Controllers controllers) : base(imageRoute + "Down/1", rectangle)
        {
            int speed = 2;
            this.controller = controllers;
            this.player = player;
            this.scoreColor = color;
            this.scorePosition = scorePosition;
            mapKeys = new Dictionary<Keys, int>();
            mapKeys.Add(controller.getUp(), -speed);
            mapKeys.Add(controller.getDown(), speed);
            mapKeys.Add(controller.getRight(), speed);
            mapKeys.Add(controller.getLeft(), -speed);

            allKeys = new List<Keys>();
            allKeys.Add(controller.getUp());
            allKeys.Add(controller.getDown());
            allKeys.Add(controller.getLeft());
            allKeys.Add(controller.getRight());

            imagesXDirections = new Dictionary<Keys, Dictionary<int, Texture2D>>();
            imagesXDirections.Add(controller.getUp(), this.buildImagesRoutes(imageRoute + "Up/"));
            imagesXDirections.Add(controller.getDown(), this.buildImagesRoutes(imageRoute + "Down/"));
            imagesXDirections.Add(controller.getLeft(), this.buildImagesRoutes(imageRoute + "Left/"));
            imagesXDirections.Add(controller.getRight(), this.buildImagesRoutes(imageRoute + "Right/"));

            this.bombs = new List<Bomb>();
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
            if (this.isKeyDownAndNot(controller.getUp()))
            {
                updateImage(gameTime, controller.getUp());
                this.modifyBombermanPosition(controller.getUp());
            }

            if (this.isKeyDownAndNot(controller.getDown()))
            {
                updateImage(gameTime, controller.getDown());
                this.modifyBombermanPosition(controller.getDown());
            }

            if (this.isKeyDownAndNot(controller.getLeft()))
            {
                updateImage(gameTime, controller.getLeft());
                this.modifyBombermanPosition(controller.getLeft());
            }

            if (this.isKeyDownAndNot(controller.getRight()))
            {
                updateImage(gameTime, controller.getRight());
                this.modifyBombermanPosition(controller.getRight());
            }

            if (Keyboard.GetState().IsKeyDown(controller.getAction()) && gameTime.TotalGameTime.Subtract(tiempoBomba).Milliseconds > 500)
            {
                tiempoBomba = gameTime.TotalGameTime;

                Bomb bomb = new Bomb(new Rectangle(base.currentFrame.X, base.currentFrame.Y, base.currentFrame.Width, base.currentFrame.Height), gameTime.TotalGameTime);
                Background.getInstance().addBombs(bomb);
            }
        }

        private Boolean isKeyDownAndNot(Keys key)
        {
            List<Keys> cpyAllKeys = new List<Keys>();
            allKeys.ForEach(elements => { if (elements != key) { cpyAllKeys.Add(elements); } });
            return Keyboard.GetState().IsKeyDown(key) && !Keyboard.GetState().IsKeyDown(cpyAllKeys[0]) && !Keyboard.GetState().IsKeyDown(cpyAllKeys[1]) && !Keyboard.GetState().IsKeyDown(cpyAllKeys[2]);

        }

        private void modifyBombermanPosition(Keys key)
        {
            int xPosition = currentFrame.X;
            int yPosition = currentFrame.Y;
            if (key.Equals(controller.getUp()) || key.Equals(controller.getDown()))
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

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            this.drawPoints(gameTime, player, this.scoreColor, this.scorePosition);
        }

        public void drawPoints(GameTime gameTime, String player, Color color, Vector2 vector)
        {;
            BombermanGame.getInstance().spriteBatch.DrawString(
            BombermanGame.getInstance().visualScore[player],
            player + ": " + BombermanGame.getInstance().scoreByBomberman[player].ToString(),
            vector,
            color);
        }
    }
}
