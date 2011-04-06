using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Core;
using Core.Enums;

namespace SoccerEngine
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class SoccerEngine : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        float deltaFPSTime = 0;

        public static List<Animation> playerAnimations = new List<Animation>();
        public static List<Animation> ballAnimations = new List<Animation>();

        public static Texture2D[,] playerTextures = new Texture2D[4, 2];
        public static Texture2D[,] ballTextures = new Texture2D[4, 2];

        public static GamePlayer Player;
        public static GameMatch Match;
        public static Camera camera = new Camera();

        public SoccerEngine()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            LoadPlayerSprites();
            LoadBallSprites();

            CreatePlayerAnimations();
            CreateBallAnimations();

            GameStadium Stadium = new GameStadium(spriteBatch, Texture2D.FromFile(GraphicsDevice, @"Graphics\Stadium\Template2.png"), Texture2D.FromFile(GraphicsDevice, @"Graphics\Stadium\Grass6.png")); 
           
            Player = new GamePlayer();
            Player.Sprite = new AnimatedSprite(Player, spriteBatch, playerTextures[0, 0], ClonePlayerAnimations());

            GameBall Ball = new GameBall();
            Ball.Sprite = new AnimatedSprite(Ball, spriteBatch, ballTextures[0, 0], CloneBallAnimations());
            Ball.BallPoint = new Point(450, 235);

            Match = new GameMatch(spriteBatch, Content.Load<SpriteFont>("Fonts/Small"), new GameTeam(), new GameTeam(), Stadium, Ball, 5);
            Match.StartMatch();
        }

        private void LoadPlayerSprites()
        {
            playerTextures[0, 0] = Texture2D.FromFile(GraphicsDevice, @"Graphics\Characters\Test1.png");
        }

        private void LoadBallSprites()
        {
            ballTextures[0, 0] = Texture2D.FromFile(GraphicsDevice, @"Graphics\Ball\TestBall.png");
        }

        private void CreatePlayerAnimations()
        {
            //Left
            Animation tempAnimation = new Animation(1, 20, 32, 0, 0);//left
            playerAnimations.Add(tempAnimation);

            //runLeft
            tempAnimation = new Animation(4, 20, 32, 20, 0);//left
            playerAnimations.Add(tempAnimation);

            //shootLeft
            tempAnimation = new Animation(1, 20, 32, 100, 0);//left
            playerAnimations.Add(tempAnimation);

            //Rigth
            tempAnimation = new Animation(1, 20, 32, 120, 0);//right
            playerAnimations.Add(tempAnimation);

            //runRigth
            tempAnimation = new Animation(4, 20, 32, 140, 0);//right
            playerAnimations.Add(tempAnimation);

            //shootRight
            tempAnimation = new Animation(1, 20, 32, 220, 0);//right
            playerAnimations.Add(tempAnimation);
           
            //Up
            tempAnimation = new Animation(1, 20, 32, 240, 0);//up
            playerAnimations.Add(tempAnimation);

            //runUp
            tempAnimation = new Animation(5, 20, 32, 260, 0);//up
            playerAnimations.Add(tempAnimation);

            //shootUp
            tempAnimation = new Animation(1, 20, 32, 340, 0);//up
            playerAnimations.Add(tempAnimation);

            //Down
            tempAnimation = new Animation(5, 20, 32, 360, 0);//down
            playerAnimations.Add(tempAnimation);

            //runDown
            tempAnimation = new Animation(5, 20, 32, 380, 0);//down
            playerAnimations.Add(tempAnimation);

            //shootDown
            tempAnimation = new Animation(1, 20, 32, 460, 0);//down
            playerAnimations.Add(tempAnimation);

            //HeaderLeft
            tempAnimation = new Animation(2, 20, 32, 480, 0);//left
            playerAnimations.Add(tempAnimation);

            //HeaderRight
            tempAnimation = new Animation(2, 20, 32, 520, 0);//right
            playerAnimations.Add(tempAnimation);

            //HeaderUp
            tempAnimation = new Animation(2, 20, 32, 560, 0);//up
            playerAnimations.Add(tempAnimation);

            //HeaderDown
            tempAnimation = new Animation(2, 20, 32, 600, 0);//down
            playerAnimations.Add(tempAnimation);

            //TackeUp
            tempAnimation = new Animation(2, 20, 32, 640, 0);//up
            playerAnimations.Add(tempAnimation);

            //TackeRight
            tempAnimation = new Animation(2, 20, 32, 680, 0);//right
            playerAnimations.Add(tempAnimation);

            //TackeDown
            tempAnimation = new Animation(2, 20, 32, 720, 0);//down
            playerAnimations.Add(tempAnimation);

            //TackeLeft
            tempAnimation = new Animation(2, 20, 32, 760, 0);//left
            playerAnimations.Add(tempAnimation);
        }

        private void CreateBallAnimations()
        {
            Animation tempAnimation = new Animation(4, 16, 16, 0, 0);//RedBall
            ballAnimations.Add(tempAnimation);

            tempAnimation = new Animation(4, 16, 16, 160, 0);//BlueRedBall
            ballAnimations.Add(tempAnimation);

            tempAnimation = new Animation(4, 16, 16, 240, 0);//NormalBall
            ballAnimations.Add(tempAnimation); ;
        }

        public static List<Animation> ClonePlayerAnimations()
        {
            List<Animation> newAnimation = new List<Animation>();

            foreach (Animation a in playerAnimations)
            {
                Animation clonedAnimation = (Animation)a.Clone();
                newAnimation.Add(clonedAnimation);
            }

            return newAnimation;
        }

        public static List<Animation> CloneBallAnimations()
        {
            List<Animation> newAnimation = new List<Animation>();

            foreach (Animation a in ballAnimations)
            {
                Animation clonedAnimation = (Animation)a.Clone();
                newAnimation.Add(clonedAnimation);
            }

            return newAnimation;
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Match != null)
                Match.Update(gameTime);

            if (Player != null)
                Player.Update(gameTime);

            HandleKeyBoard();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedRealTime.TotalSeconds;

            float fps = 1 / elapsed;
            deltaFPSTime += elapsed;
            if (deltaFPSTime > 1)
            {
                Window.Title = "Soccer Engine [" + (int)fps + " FPS]";
                deltaFPSTime -= 1;
            }
            this.Window.Title = "Soccer Engine [" + (int)fps + " FPS]";

            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (Match != null)
                Match.Draw(gameTime, camera);

            if (Player != null)
                Player.Draw(gameTime, camera);

            base.Draw(gameTime);
        }

        private void HandleKeyBoard()
        {
            if (Player != null)
            {
                KeyboardState KBoard = Keyboard.GetState();
                Directions Dir = Directions.Any;

                Keys[] PresKeys = new Keys[4];

                if (KBoard.IsKeyDown(Keys.Up))
                {
                    PresKeys[0] = Keys.Up;
                    Dir = Directions.North;
                }
                if (KBoard.IsKeyDown(Keys.Left))
                {
                    PresKeys[1] = Keys.Left;
                    Dir = Directions.West;
                }
                if (KBoard.IsKeyDown(Keys.Right))
                {
                    PresKeys[2] = Keys.Right;
                    Dir = Directions.Lest;
                }
                if (KBoard.IsKeyDown(Keys.Down))
                {
                    PresKeys[3] = Keys.Down;
                    Dir = Directions.South;
                }

                if (Player.Char.isShooting || Player.Char.isTacking)
                    if (DateTime.Now > Player.Char.LastAction)
                        Player.Char.IdleAnimation();

                if (KBoard.IsKeyDown(Keys.NumPad1) && Player.Char.LastSpecial < DateTime.Now || KBoard.IsKeyDown(Keys.NumPad2) && Player.Char.LastSpecial < DateTime.Now)
                    Player.Char.ShootTo(Dir);
                else if (KBoard.IsKeyDown(Keys.NumPad3) && Player.Char.LastSpecial < DateTime.Now)
                    Player.Char.TackleTo(Dir);
                else
                    Player.Char.RunTo(Dir);

                Player.Char.Move(PresKeys);

                camera.LockToSprite(Player.Char);
            }
        }
    }
}
