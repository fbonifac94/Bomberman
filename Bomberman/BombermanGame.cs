using Bomberman.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Bomberman
{
    public class BombermanGame : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch { get; set; }
        protected static BombermanGame bombermanGame { get; private set; }
        private List<BombermanEntity> bombermans;
        private Background background;

        private BombermanGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            bombermans = new List<BombermanEntity>();
        }

        public static BombermanGame getInstance()
        {
            if (BombermanGame.bombermanGame == null)
            {
                BombermanGame.bombermanGame = new BombermanGame();
            }
            return BombermanGame.bombermanGame;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            bombermans.Add(BombermanPlayerOne.getInstance());
            bombermans.Add(BombermanPlayerTwo.getInstance());
            background = Background.getInstance();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < bombermans.Count; i++)
            {
                bombermans[i].Update(gameTime);
                if (background.fireIntersectSomething(bombermans[i].getCurrentPosition()))
                {
                    if (bombermans[i] is BombermanPlayerOne)
                    {

                    }
                    else
                    {

                    }
                    background = Background.getInstance(true);
                    bombermans.Clear();
                    bombermans.Add(BombermanPlayerOne.getInstance(true));
                    bombermans.Add(BombermanPlayerTwo.getInstance(true));
                }
            }
            background.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            background.Draw(gameTime);

            foreach (BombermanEntity bomberman in bombermans)
            {
                bomberman.Draw(gameTime);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
