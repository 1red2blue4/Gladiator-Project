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
using Microsoft.Xna.Framework.Audio;
#endregion


namespace GladiatorProject
{
    /// <summary>
    /// The static ContentManager is responsible for taking information parsed and initialized in 
    /// the Game1 class and creating the corresponding game assets.  It will have (at least) attributes for 
    /// animations ( <string, Animations> dictionary) and for sounds (<string, SoundData> dictionary).  Methods in 
    /// this class include (at least) CreateAnimation, CreateSound, and corresponding get methods.  
    /// </summary>
    static class ContentManager
    {
        public static Dictionary<string, Animations> animationDictionary = new Dictionary<string, Animations>();
        public static Dictionary<string, List<SoundEffect>> soundDictionary = new Dictionary<string,List<SoundEffect>>();
        public static Animations tempAnim;
        public static void CreateAnimation(List<Texture2D> _texture, string _name, int numAnims)
        {
            string line;
            string[] tempArray;
            bool canParse;
            List<AnimationData> dataList = new List<AnimationData>();
            AnimationData data;
            int rows, columns, milliseconds, i = 0;
            System.IO.StreamReader file = new System.IO.StreamReader("../../../Content/AnimationData/" + _name + ".txt");
            tempAnim = new Animations();
            while ((line = file.ReadLine()) != null)
            {
                tempArray = line.Split(',');
                canParse = int.TryParse(tempArray[1], out milliseconds);
                canParse = int.TryParse(tempArray[2], out rows);
                canParse = int.TryParse(tempArray[3], out columns);
                data = new AnimationData(tempArray[0], rows, columns, _texture[i], milliseconds);
                i++;
                tempAnim.AddAnimation(data, tempArray[0]);
                numAnims--;
                if (numAnims == 0)
                    animationDictionary.Add(_name, tempAnim);
            }
            file.Close();
        }
        public static void CreateSound(List<SoundEffect> sounds, string _name)
        {
            soundDictionary.Add(_name, sounds);
        }
        public static Animations GetAnimations(string _key)
        {
            return animationDictionary[_key];
        }
        public static List<SoundEffect> GetSounds(string _key)
        {
            return soundDictionary[_key];
        }
    }
}
