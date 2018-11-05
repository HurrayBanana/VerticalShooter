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
using Template.Game;
namespace Template.Title
{
    /// <summary>
    /// generates graphs for display
    /// </summary>
    public class TitleSetup : IGameMode
    {
        private Event evLogic;
        //implement interface property using long method
        public string Description { get { return "Title Mode"; } }

        /// <summary>
        /// constructor
        /// </summary>
        public TitleSetup() 
        {
            GM.engineM.DebugDisplay = Debug.all;
            GM.engineM.ScreenColour = Color.Gray;
            new Cursor(GM.screenSize.Center);
            GM.eventM.AddEvent(evLogic = new Event(GM.eventM.MaximumRate, "container logic", Logic));
        }


        /// <summary>
        /// 
        /// </summary>
        private void Logic()
        {
            if (GM.inputM.KeyPressed(Keys.D1))
            {
                StartGame();
            }
            if (GM.inputM.KeyPressed(Keys.Escape))
            {
                GM.ClearAllManagedObjects();
                GM.CloseSystem();
            }

        }

        private void StartGame()
        {
            //tidy up before moving to another mode
            GM.eventM.Remove(evLogic);
            GM.ClearAllManagedObjects();
            GM.active = new GameSetup();
        }
    }
}
