using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SHMUPZ
{
    class GamePlay
    {
        Camera myCamera;

        Player myPlayer;

        Texture2D PlayerTexture;


        GraphicsDevice myGraphics;

        Texture2D LayerFloorText;
        Layer LayerFloor;

        Texture2D CloudsFloorText;
        Layer CloudsFloor;

        Texture2D SpeedLinesText;
        Layer SpeedLines;

        float ScrollSpeedY = 2.0f;

        bool isBoost = false; //temporary

        public GamePlay(ContentManager thisContent, GraphicsDevice thisGraphics, Vector2 ScreenSize)
        {
            myCamera = new Camera();

            myGraphics = thisGraphics;

            Vector2 cameraTranslate = Vector2.Zero;
            cameraTranslate.Y = 0;
            myCamera.Position = cameraTranslate;

            PlayerTexture = thisContent.Load<Texture2D>("gb_walk");

            myPlayer = new Player(PlayerTexture, Vector2.Zero);

            LayerFloorText = thisContent.Load<Texture2D>("FloorTile");
            LayerFloor = new Layer(LayerFloorText, 0.75f, ScrollSpeedY, 0.0f);

            CloudsFloorText = thisContent.Load<Texture2D>("Clouds2");
            CloudsFloor = new Layer(CloudsFloorText, 1.25f, ScrollSpeedY, 1.0f);

            SpeedLinesText = thisContent.Load<Texture2D>("SpeedLines");
            SpeedLines = new Layer(SpeedLinesText, 2.5f, ScrollSpeedY, 0.0f);


        }
        public void Update(GameTime gameTime)
        {
            myPlayer.Update(gameTime);

            LayerFloor.Update(gameTime, ScrollSpeedY);
            CloudsFloor.Update(gameTime, ScrollSpeedY);
            SpeedLines.Update(gameTime, ScrollSpeedY);

            KeyboardState newKeyState = Keyboard.GetState();
            if (newKeyState.IsKeyDown(Keys.Space))
            {
                isBoost = true;
                ScrollSpeedY = 4.0f;
            }
            else
            {
                isBoost = false;
                ScrollSpeedY = 2.0f;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            myGraphics.Clear(Color.Black);
            LayerFloor.Draw(spriteBatch);

            myPlayer.Draw(spriteBatch, myCamera);

            CloudsFloor.Draw(spriteBatch);
            if (isBoost == true)
            {
                SpeedLines.Draw(spriteBatch);
            }
        }
    }
}
