using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SHMUPZ
{
    class GameStateManager
    {
        MenuManager myMenu;
        GameplayManager myGameplay;


        public enum MyGameState
        {
            Menu, Gameplay, Credits
        }
        MyGameState myState = MyGameState.Menu;


        ContentManager myContent;
        GraphicsDevice myGraphics;
        Vector2 ScreenSize;

        public GameStateManager(ContentManager thisContent, GraphicsDevice thisGraphics, Vector2 pScreenSize)
        {
            ScreenSize = pScreenSize;

            myContent = thisContent;
            myGraphics = thisGraphics;
            ScreenSize = pScreenSize;
        }
        public void Update(GameTime gameTime)
        {
            switch (myState)
            {
                case MyGameState.Menu:
                    if (myMenu == null)
                    {
                        myMenu = new MenuManager(myContent, myGraphics, ScreenSize);
                    }
                    else
                    {
                        myMenu.Update(gameTime);
                        if (myMenu.myState != MenuManager.MyGameState.Menu)
                        {

                            if (myMenu.myState == MenuManager.MyGameState.Gameplay)
                            {
                                
                                myState = MyGameState.Gameplay;
                            }
                            if (myMenu.myState == MenuManager.MyGameState.Credits)
                            {
                                
                                myState = MyGameState.Credits;
                            }
                            myMenu = null;
                        }
                    }
                    break;
                case MyGameState.Gameplay:
                    if (myGameplay == null)
                    {
                        myGameplay = new GameplayManager(myContent, myGraphics, ScreenSize);
                    }
                    else
                    {
                        myGameplay.Update(gameTime);
                    }
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            switch (myState)
            {
                case MyGameState.Menu:
                    if (myMenu != null)
                    {
                        myMenu.Draw(spriteBatch);
                    }
                    break;
                case MyGameState.Gameplay:
                    if (myGameplay != null)
                    {
                        myGameplay.Draw(spriteBatch);
                    }
                    break;
            }
        }
    }
}
