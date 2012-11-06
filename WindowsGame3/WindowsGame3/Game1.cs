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

namespace MovingAndColissions1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {


        GraphicsDeviceManager    graphics;

        SpriteBatch           spriteBatch;

        SpriteFont    Arial;


        Texture2D          tEarth;
        Texture2D      tPaddleOne;
        Texture2D      tPaddleTwo;


        Rectangle      rPaddleOne;
        Rectangle      rPaddleTwo;
        Rectangle           rBall;
    
        Ball oBall;
        Paddle oPaddleOne;
        Paddle oPaddleTwo;

        KeyboardState oldKeyboard;
        KeyboardState currentKeyboard;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth  = 800;
            graphics.PreferredBackBufferHeight = 600;

            graphics.ApplyChanges();









        }






        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            oldKeyboard     = new KeyboardState();
            currentKeyboard = new KeyboardState();

            //Ball takes a Point object in its constructor.
            //we must therefore instantiate Point at the same time as the new Ball()
            // (   new Point( x,  y)   )



            oBall = new Ball(new Point(graphics.GraphicsDevice.Viewport.Width/2, graphics.GraphicsDevice.Viewport.Height/2));

            oPaddleOne = new Paddle(new Vector2(0, graphics.GraphicsDevice.Viewport.Height/2));
            //oPaddleTwo = new Paddle(new Vector2((graphics.GraphicsDevice.Viewport.Bounds.Right - tPaddleOne.Width), graphics.GraphicsDevice.Viewport.Height/2));









            base.Initialize();

            //Any objects referencing 'previous' objects, must be instantiated after Initialize();


            rPaddleOne = new Rectangle((int)oPaddleOne.vPosition.X, (int)oPaddleOne.vPosition.Y,
                tPaddleOne.Width, tPaddleOne.Height);
            //rPaddleTwo = new Rectangle((int)oPaddleTwo.vPosition.X, (int)oPaddleTwo.vPosition.Y,
            //    tPaddleTwo.Width, tPaddleTwo.Height);
            rBall = new Rectangle((int)oBall.pPosition.X, (int)oBall.pPosition.Y,
                tEarth.Width, tEarth.Height);








        }






        void Reset()
        {


            oBall = new Ball(new Point(400, 300));

            oPaddleOne = new Paddle(new Vector2(0, 300));
            oPaddleTwo = new Paddle(new Vector2((graphics.GraphicsDevice.Viewport.Bounds.Right - tPaddleOne.Width), 300));



            rPaddleOne = new Rectangle((int)oPaddleOne.vPosition.X, (int)oPaddleOne.vPosition.Y,
                tPaddleOne.Width, tPaddleOne.Height);
            rPaddleTwo = new Rectangle((int)oPaddleTwo.vPosition.X, (int)oPaddleTwo.vPosition.Y,
                tPaddleTwo.Width, tPaddleTwo.Height);

            rBall = new Rectangle((int)oBall.pPosition.X, (int)oBall.pPosition.Y,
                tEarth.Width, tEarth.Height);


        }















        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tEarth = Content.Load<Texture2D>("tEarth") as Texture2D;
            tPaddleOne = Content.Load<Texture2D>("pongpaddle") as Texture2D;
            tPaddleTwo = Content.Load<Texture2D>("pongpaddle") as Texture2D;
            Arial = Content.Load<SpriteFont>("Arial");






            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        /// 



        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here




        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        protected override void Update(GameTime gameTime)
        {

            oldKeyboard = currentKeyboard;
            currentKeyboard = Keyboard.GetState();

            //verify key
            //verify boundaries.
            if ( (IsHeld(Keys.Up) && (oBall.pPosition.Y > graphics.GraphicsDevice.Viewport.Bounds.Top)) )
            {
                oBall.pPosition.Y += -6;
            }


            if ((IsHeld(Keys.Down) && ((oBall.pPosition.Y + tEarth.Height) < graphics.GraphicsDevice.Viewport.Height)))
            {
                oBall.pPosition.Y += 6;
            }


            if ( (IsHeld(Keys.Left) && (oBall.pPosition.X > graphics.GraphicsDevice.Viewport.Bounds.Left))  )
            {
                oBall.pPosition.X += -6;
            }

            if ( (IsHeld(Keys.Right) && (oBall.pPosition.X < (graphics.GraphicsDevice.Viewport.Bounds.Right - tEarth.Width))) )
            {
                oBall.pPosition.X += +6;
            }





            rBall.X = oBall.pPosition.X;
            rBall.Y = oBall.pPosition.Y;

            rPaddleOne.X = (int)oPaddleOne.vPosition.X;
            rPaddleOne.Y = (int)oPaddleOne.vPosition.Y;

            rPaddleTwo.X = (int)oPaddleTwo.vPosition.X;
            rPaddleTwo.Y = (int)oPaddleTwo.vPosition.Y;




            if(IsReleased(Keys.Space))
            {
                //add what should happen is space is released
            }





            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();





            // TODO: Add your update logic here

            base.Update(gameTime);
        }










        //Check to see if key is down
        public bool IsHeld(Keys key)
        {
            if (currentKeyboard.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //check to see if the key was just released()
        public bool IsReleased(Keys key)
        {
            if ((currentKeyboard.IsKeyUp(key) && oldKeyboard.IsKeyDown(key)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Check to see fi the key was just pressed.
        public bool JustPressed(Keys key)
        {
            if ((currentKeyboard.IsKeyDown(key) && oldKeyboard.IsKeyUp(key)) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }











        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {



            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here


            spriteBatch.Begin();

            spriteBatch.Draw(tEarth,
                new Vector2(oBall.pPosition.X, oBall.pPosition.Y),
                Color.White);

            spriteBatch.Draw(tPaddleOne,
                new Vector2(oPaddleOne.vPosition.X, oPaddleOne.vPosition.Y), 
                Color.White);

            spriteBatch.Draw(tPaddleTwo,
                new Vector2(oPaddleTwo.vPosition.X, oPaddleTwo.vPosition.Y),
                Color.White);




            if(IsHeld(Keys.Space))
            {
                spriteBatch.DrawString(
                    Arial, 
                    "OUCH!!, That's Smarts!", 
                    new Vector2(200, 100), 
                    Color.Red
                    );

            }


            spriteBatch.End();

            base.Draw(gameTime);

        }







    }
}
