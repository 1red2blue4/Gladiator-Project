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
    class Level
    {
        const int numLevels = 1;
        string line;
        Dictionary<string, GameObject> objectDictionary;
        string tempX, tempY;
        GameObject obj;
        Vector2 vector;
        char type;
        string name;

        bool canParse;
        public Level()
        {
            objectDictionary = new Dictionary<string, GameObject>();
        }

        public void LoadLevel(char _index)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("../../../Content/Levels/Level" + _index + ".txt");
            Initialize(file);
        }
        public void Initialize(System.IO.StreamReader _file)
        {
            while ((line = _file.ReadLine()) != null)
            {
               // Read level file here

                // Switch statement for character index "type"
                switch(type)
                {
                    default:
                        //obj = new GameObject(name, vector, ContentManager.GetAnimations(type));
                        break;
                }

                ObjectHandler.AddToObjectDictionary(obj, name);
            }
            _file.Close();
        }

    }
}
