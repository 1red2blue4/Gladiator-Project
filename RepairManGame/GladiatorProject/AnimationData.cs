using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace GladiatorProject
{// Contains a list (so dict doesn't have to be lists)
    public class AnimationData
    {
        /// <summary>
        /// Milliseconds per frame
        /// </summary>
        public int milliseconds { get; set; }
        /// <summary>
        /// Name of the sprite
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Rows in the sprite
        /// </summary>
        public int rows { get; set; }
        /// <summary>
        /// Columns in the sprite
        /// </summary>
        public int cols { get; set; }
        /// <summary>
        /// The sprite
        /// </summary>
        public Texture2D sprite { get; set; }
        /// <summary>
        /// Paramaterized Constructor
        /// </summary>
        /// Name
        /// <param name="n"></param>
        /// Rows
        /// <param name="r"></param>
        /// Columns
        /// <param name="c"></param>
        /// SpriteSheet
        /// <param name="s"></param>
        /// Milliseconds per frame
        /// <param name="mpf"></param>
        public AnimationData(string n, int r, int c, Texture2D s, int mpf)
        {
            milliseconds = mpf;
            name = n;
            rows = r;
            cols = c;
            sprite = s;
        }
        
    }
}
