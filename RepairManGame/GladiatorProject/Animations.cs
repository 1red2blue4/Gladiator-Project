//Galactic Repair
    //Aaron Collins
    //Daniel Lowery
    //Mark Obeldobel
    //Alex Stiffman
//Professor Bierre
//IGME-106
//8:00 a.m.

﻿#region Using Statements
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
    /// Is an attribute of game objects
    /// that contains a dictionary of that 
    /// object's animations
    /// and the number of animations
    /// </summary>
    class Animations
    {
        /// <summary>
        /// Dictionary of animations for the GameObject
        /// </summary>
        public Dictionary<string, AnimationData> sprites = new Dictionary<string, AnimationData>();
        /// <summary>
        /// Number of animations
        /// </summary>
        public int numAnims = 0;
        /// <summary>
        /// Adds an animation to the dictionary of the object's animations
        /// </summary>
        /// <param name="data"></param>
        /// <param name="animName"></param>
        public void AddAnimation(AnimationData data, string animName)
        {
            sprites.Add(animName, data);
            numAnims++;
        }
        /// <summary>
        /// Returns a AnimationData value from the _name key
        /// </summary>
        /// The name key
        /// <param name="_name"></param>
        /// <returns></returns>
        public AnimationData getSprite(string _name)
        {
            // If/else statement that truncates the duplicate index of _name
            string c = "_";
            string[] truncate;
            if (_name.Contains(c) == true)
            {
                truncate = _name.Split('_');
                return sprites[truncate[1]];
            }
            else
                return sprites[_name];
        }
    }
}
