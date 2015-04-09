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

namespace TheSolarSystem
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D sun, earth, mercury, venus, mars, jupiter, saturn, uranus, neptune, pluto;
        int ex, ey, mx, my, vx, vy, marsX, marsY, jx, jy, sx, sy, ux, uy, nx, ny, px, py, 
                loop, mercuryLoop, venusLoop, marsLoop, jLoop, sLoop, uLoop, nLoop, pLoop;
        double theta, mTheta, vTheta, marsTheta, jTheta, sTheta, uTheta, nTheta, pTheta;
        Vector2 v2, v3, v4, v5, v6, v7, v8, v9, v10;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = 1920;
            this.graphics.PreferredBackBufferHeight = 1080;
            this.graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
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
            theta = 0;
            mTheta = 0;
            vTheta = 0;
            marsTheta = 0;
            sTheta = 0;
            uTheta = 0;
            nTheta = 0;
            pTheta = 0;
            loop = 0; // Earth
            mercuryLoop = 0;
            venusLoop = 0;
            marsLoop = 0;
            sLoop = 0;
            uLoop = 0;
            nLoop = 0;
            pLoop = 0;
            v2 = new Vector2(ex, ey); //Earth
            v3 = new Vector2(mx, my); //Mercury
            v4 = new Vector2(vx, vy); //Venus
            v5 = new Vector2(marsX, marsY); //Mars
            v6 = new Vector2(jx, jy); //Jupiter
            v7 = new Vector2(sx, sy); //Saturn
            v8 = new Vector2(ux, uy); //Uranus
            v9 = new Vector2(nx, ny); //Neptune
            v10 = new Vector2(px, py); //Pluto

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            earth = Content.Load<Texture2D>(@"images/earth");
            sun = Content.Load<Texture2D>(@"images/sun");
            mercury = Content.Load<Texture2D>(@"images/mercury");
            venus = Content.Load<Texture2D>(@"images/venus");
            mars = Content.Load<Texture2D>(@"images/mars");
            jupiter = Content.Load<Texture2D>(@"images/jupiter");
            saturn = Content.Load<Texture2D>(@"images/saturn");
            uranus = Content.Load<Texture2D>(@"images/uranus");
            neptune = Content.Load<Texture2D>(@"images/neptune");
            pluto = Content.Load<Texture2D>(@"images/pluto");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            /* Each loop below orbits its respected planet around the sun.
             * For each loop I took the representation of an Earth year (theta + 0.05)
             * and devided it by the planet that's controled by the loop to get a realistic orbit.
             */
            if (loop == 5) // Earth
           {
                theta = (theta > 360) ? 0 : (theta + 0.05); // Representation of Earth year
                ex = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(theta) * Math.PI / 220);
                ey = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(theta) * Math.PI / 220);
                v2.X = ex;
                v2.Y = ey;
                loop = 0;
            }
            else loop++;

            if (mercuryLoop == 5)
            {
                mTheta = (mTheta > 360) ? 0 : (mTheta + 0.207469); // Earch year / Mercury year
                mx = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(mTheta) * Math.PI / 360);
                my = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(mTheta) * Math.PI / 360);
                v3.X = mx;
                v3.Y = my;
                mercuryLoop = 0;
            }
            else mercuryLoop++;

            if (venusLoop == 5)
            {
                vTheta = (vTheta > 360) ? 0 : (vTheta + 0.081301); // Earth year / venus year
                vx = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(vTheta) * Math.PI / 290);
                vy = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(vTheta) * Math.PI / 290);
                v4.X = vx;
                v4.Y = vy;
                venusLoop = 0;
            }
            else venusLoop++;

            if (marsLoop == 5)
            {
                marsTheta = (marsTheta > 360) ? 0 : (marsTheta + 0.026596); // Earth year / mars year
                marsX = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(marsTheta) * Math.PI / 200);
                marsY = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(marsTheta) * Math.PI / 200);
                v5.X = marsX;
                v5.Y = marsY;
                marsLoop = 0;
            }
            else marsLoop++;

            if (jLoop == 5)
            {
                jTheta = (jTheta > 360) ? 0 : (jTheta + 0.004213); // Earth year / jupiter year
                jx = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(jTheta) * Math.PI / 180);
                jy = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(jTheta) * Math.PI / 180);
                v6.X = jx;
                v6.Y = jy;
                jLoop = 0;
            }
            else jLoop++;

            if (sLoop == 5)
            {
                sTheta = (sTheta > 360) ? 0 : (sTheta + 0.001697); // Earth year / Saturn year
                sx = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(sTheta) * Math.PI / 100);
                sy = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(sTheta) * Math.PI / 100);
                v7.X = sx;
                v7.Y = sy;
                sLoop = 0;
            }
            else sLoop++;

            if (uLoop == 5)
            {
                uTheta = (uTheta > 360) ? 0 : (uTheta + 0.000595); // Earth year / Uranus year
                ux = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(uTheta) * Math.PI / 80);
                uy = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(uTheta) * Math.PI / 80);
                v8.X = ux;
                v8.Y = uy;
                uLoop = 0;
            }
            else uLoop++;

            if (nLoop == 5)
            {
                nTheta = (nTheta > 360) ? 0 : (nTheta + 0.000303); // Earth year / Nepturne year
                nx = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(nTheta) * Math.PI / 60);
                ny = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(nTheta) * Math.PI / 60);
                v9.X = nx;
                v9.Y = ny;
                nLoop = 0;
            }
            else nLoop++;

            if (pLoop == 5)
            {
                pTheta = (pTheta > 360) ? 0 : (pTheta + 0.000202); // Earth year / pluto year
                px = Window.ClientBounds.Width / 2 + (int)(10000 * Math.Cos(pTheta) * Math.PI / 50);
                py = Window.ClientBounds.Height / 2 + (int)(10000 * Math.Sin(pTheta) * Math.PI / 50);
                v10.X = px;
                v10.Y = py;
                pLoop = 0;
            }
            else pLoop++;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            // finds the center of the screen for the sun
            Vector2 screenCenter = new Vector2(GraphicsDevice.Viewport.Width / 2f, GraphicsDevice.Viewport.Height / 2f);
            Vector2 imageCenter = new Vector2(sun.Width / 2f, sun.Height / 2f);

            spriteBatch.Begin();
            spriteBatch.Draw(sun, screenCenter, null, Color.White, 0f, imageCenter, 1f, SpriteEffects.None, 0f);
            spriteBatch.Draw(earth, v2, Color.White);
            spriteBatch.Draw(mercury, v3, Color.White);
            spriteBatch.Draw(venus, v4, Color.White);
            spriteBatch.Draw(mars, v5, Color.White);
            spriteBatch.Draw(jupiter, v6, Color.White);
            spriteBatch.Draw(saturn, v7, Color.White);
            spriteBatch.Draw(uranus, v8, Color.White);
            spriteBatch.Draw(neptune, v9, Color.White);
            spriteBatch.Draw(pluto, v10, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
