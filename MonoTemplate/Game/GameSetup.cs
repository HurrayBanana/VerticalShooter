using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
//--engine import
using Engine;
using Template.Title;

namespace Template.Game
{
    class GameSetup : IGameMode
    {
        private Event evLogic;
        //implement interface property using short form
        public string Description => "Game Mode";

        public GameSetup()
        {
            GM.engineM.DebugDisplay = Debug.fps | Debug.version;
            GM.engineM.ScreenColour = Color.Black;
            GM.eventM.AddEvent(evLogic = new Event(GM.eventM.MaximumRate, "container logic", Logic));

        }

        private void Logic()
        {
            if (GM.inputM.KeyPressed(Keys.Escape))
            {
                BackToTitle();
            }
        }


        private void BackToTitle()
        {
            //tidy up before moving to another mode
            GM.eventM.Remove(evLogic);
            GM.ClearAllManagedObjects();
            GM.active = new TitleSetup();
        }
    }
}
