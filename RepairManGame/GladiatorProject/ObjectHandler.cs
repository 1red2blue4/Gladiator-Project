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
    /// animations ( <string, Asset> dictionary) and for sounds (<string, Asset> dictionary).  Methods in 
    /// this class include (at least) CreateAnimation, CreateSound, and corresponding get methods.  
    /// These collections are not of on-screen objects but of possible on-screen objects.
    /// </summary>
    static class ObjectHandler
    {
        
        public static int[,] collisionGrid = new int[10, 10];
        public static Level currentLevel;
        public static bool collision = false;
        static bool initialUpdate = true;
        public static char[] levelIndex { get; set; }
        /// <summary>
        /// -1: previous
        /// 0: current
        /// 1: next
        /// </summary>
        public static int changeLevel = 0;
        public static Dictionary<string, GameObject> objectDictionary = objectDictionary = new Dictionary<string,GameObject>();
        public static List<string> onScreen = new List<string>();
        public static List<SoundEffect> sounds = new List<SoundEffect>();
        public static int index { get; set; }
        
        public static void AddToObjectDictionary(GameObject value, string key)
        {
            string c = "_";
            int duplicateIndex = 2;
            while(true)
            { 
                if(objectDictionary.ContainsKey(key) == false)
                {
                    objectDictionary.Add(key, value);
                    onScreen.Add(key);
                    //value.name = key;
                    return;
                }
                else
                {
                    if(key.Contains(c))
                    {
                        key = key.Substring(key.IndexOf('_')+1);
                    }
                    key = duplicateIndex.ToString() + "_" + key;
                    duplicateIndex++;
                }
            }
        }
        /// <summary>
        /// Updates each object on screen
        /// </summary>
        public static void Update(GameTime gameTime)
        {
            if(initialUpdate == true)
            {
                index = 0;
                InitializeLevel();
                initialUpdate = false;
            }
            if (changeLevel == 1)
            {
                index++;
                InitializeLevel();
                changeLevel = 0;
            }
            if (changeLevel == -1)
            {
                index--;
                InitializeLevel();
                changeLevel = 0;
            }
            if (changeLevel == 0)
            {
                for (int x = 0; x < objectDictionary.Count; x++)
                {
                    //objectDictionary[onScreen[x]].Update(gameTime);
                }
            }
        }
        /// <summary>
        /// Draws each object on screen
        /// </summary>
        public static void Draw(SpriteBatch spriteBatch)
        {
            for(int x = 0; x < objectDictionary.Count; x++)
            {
                //objectDictionary[onScreen[x]].Draw(spriteBatch);
            }
        }
        public static void InitializeLevel()
        {

            for (int x = 0; x < objectDictionary.Count; x++)
            {
                //objectDictionary[onScreen[x]].StopSounds();
            }
            ClearLevel();
            currentLevel = new Level();
            currentLevel.LoadLevel(levelIndex[index]);
        }
        public static void ClearLevel()
        {
            onScreen.Clear();
            objectDictionary.Clear();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    collisionGrid[x, y] = 0;
                }
            }
        }
        public static bool AddCollision(GameObject obj, Rectangle hB)
        {
            Rectangle _hB;
            GameObject _obj;
            for(int i = 0; i < objectDictionary.Count; i++)
            {
                //_hB = objectDictionary[onScreen[i]].GetHitBox();
                _obj = objectDictionary[onScreen[i]];
                //if (hB.Intersects(_hB) && obj != _obj && _obj.canCollide == true)
                {
                    //obj.SetCollision(_hB);
                    return true;
                }
            }
            return false;
        }
        public static GameObject GetCollision(int x, int y)
        {
            return null;
        }
    }
}
