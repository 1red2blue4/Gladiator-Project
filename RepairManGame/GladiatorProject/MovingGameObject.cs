//Galactic Repair
    //Aaron Collins
    //Daniel Lowery
    //Mark Obeldobel
    //Alex Stiffman
//Professor Bierre
//IGME-106
//8:00 a.m.

#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace GladiatorProject
{
    /// <summary>
    /// 
    /// </summary>
    class MovingGameObject : GameObject
    {
        public MovingGameObject(string nm, Vector2 pstn, Animations anmtn, Texture2D sprt, bool cnClld, bool nScrn): base(nm, pstn, anmtn, sprt, cnClld, nScrn)
        {

        }

        //every object moves differently
        //primary move method
        public virtual void Move()
        {

        }

        //secondary update method (to GameObject)
        public virtual void Update()
        {

        }

        //secondary update method (to GameObject)
        public virtual void Draw()
        {

        }
    }
}

