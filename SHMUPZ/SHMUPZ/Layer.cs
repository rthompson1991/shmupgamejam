using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace SHMUPZ
{
    class Layer
    {
        //Scalar (For paralax)
        float LayerScalarY;
        //Y Scroll Speed
        float LayerSpeedY;
        //X Scroll Speed
        float LayerSpeedX;

        Vector2 ScreenSize;

        Texture2D LayerText;

        Vector2 Position;

        float ScrollX = 0;
        float ScrollY = 0;

        public Layer(Texture2D pLayerText, float pLayerScalarY, float pLayerSpeedY, float pLayerSpeedX)
        {
            LayerScalarY = pLayerScalarY;
            LayerSpeedY = pLayerSpeedY;
            LayerSpeedX = pLayerSpeedX;

            LayerText = pLayerText;

            Position = Vector2.Zero;
        }
        public void Update(GameTime gameTime, float ScrollYSpeed)
        {
            LayerSpeedY = ScrollYSpeed;

            ScrollX += LayerSpeedX;
            ScrollY += LayerSpeedY * LayerScalarY;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            spriteBatch.Draw(LayerText, Position, new Rectangle((int)-ScrollX, (int)-ScrollY, LayerText.Width, LayerText.Height), Color.White);
            spriteBatch.End();
        }
    }
}
