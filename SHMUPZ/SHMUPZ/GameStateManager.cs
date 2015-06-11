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
    class GameStateManager
    {
        enum MyGameState
        {
            Menu, Gameplay
        }
        Texture2D StartTest;
        public GameStateManager(ContentManager thisContent, GraphicsDevice thisGraphics, Vector2 ScreenSize)
        {
            StartTest = thisContent.Load<Texture2D>("Start.png");
        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
