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
using Microsoft.Xna.Framework.Audio;
#endregion

namespace GladiatorProject
{
    /// <summary>
    /// (1) Parsing and Loading Data: 
    ///     This data includes a level grid (a text file with x rows and 
    ///     y columns of character indexes for game levels) , texture data (a text file containing the names 
    ///     and types of sprites), and sound data (a text file containing the names and types of game sounds). 
    ///     Each of these files are to be parsed in the LoadContent method.
    /// (2) Loading content:  
    ///     Content Loading is done parallel to parsing data.  The textures and 
    ///     sounds that are initialized in this method are used to set attributes and create data structures in 
    ///     classes that will be mentioned later in this document.  
    /// (3) Calling methods of static classes:
    ///     The Game1 class also calls methods of the static
    ///     classes: ContentManager (CreateAnimation & CreateSound) and ObjectHandler (Draw and Update).
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        /// <summary>
        ///  Current
        /// </summary>

        public static KeyboardState KBState;
        /// <summary>
        ///  Old
        /// </summary>
        public static KeyboardState oldKBState;
        /// <summary>
        ///  Array of levels char[x] (x can be changed based on # of levels)
        /// </summary>
        public char[] levels = new char[25];
        /// <summary>
        /// Dictionary of parsed textures
        /// </summary>
        public Dictionary<string, List<Texture2D>> textures = new Dictionary<string, List<Texture2D>>();
        /// <summary>
        /// Dictionary of parsed sounds
        /// </summary>
        public Dictionary<string, List<SoundEffect>> sounds = new Dictionary<string, List<SoundEffect>>();
        /// <summary>
        /// A Font
        /// </summary>
        SpriteFont devFont;
        /// <summary>
        /// String to hold level chars
        /// </summary>
        string tempFile;
        /// <summary>
        /// Temporary string var
        /// </summary>
        string tempString;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1080;// set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;// set this value to the desired height of your window
            // Parse LevelGrid.txt
            System.IO.StreamReader file = new System.IO.StreamReader("../../../Content/Levels/LevelGrid.txt");
            tempFile = file.ReadToEnd();
            for (int x = 0; x < 3; x++)
            {
                tempString = tempFile.Substring(x, 1);
                levels[x] = Convert.ToChar(tempString);
            }
            // Set the ObjectHandler's levelIndex
            ObjectHandler.levelIndex = levels;
            file.Close();
            // Apply graphics changes
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Initialize Vars
            string line;
            string[] split = new string[2];
            int numTextures = 0, numSounds = 0;
            string name = "";
            int i = 0, _numTextures = 0, _numSounds = 0;
            List<Texture2D> tempTextures = new List<Texture2D>();
            List<SoundEffect> tempSounds = new List<SoundEffect>();
            List<string> lines = new List<string>();
            List<string[]> splits = new List<string[]>();
            Texture2D tempTexture;
            SoundEffect tempSound;
            string dataString;
            devFont = Content.Load<SpriteFont>("MyFont");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Initialize IO Stream
            System.IO.StreamReader file = new System.IO.StreamReader("../../../Content/Textures/TextureData.txt");
            // Parse the TextureData file
            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
                if (line.Contains(",") && i == 0)
                {
                    split = line.Split(',');
                    name = split[0];
                    numTextures = int.Parse(split[1]);
                    _numTextures = numTextures;
                    i = 1;
                }
                else if (i == 1 && line.Contains(",") == false)
                {
                    dataString = line;
                    tempTexture = Content.Load<Texture2D>(dataString);
                    tempTextures.Add(tempTexture);
                    if (textures.ContainsKey(name) == false)
                        textures.Add(name, tempTextures);
                    _numTextures--;
                    if (_numTextures == 0)
                    {
                        ContentManager.CreateAnimation(textures[name], name, numTextures);
                        tempTextures.Clear();
                        i = 0;
                    }
                }
            }
            file.Close();
            lines.Clear();
            // Initialize IO stream
            System.IO.StreamReader file2 = new System.IO.StreamReader("../../../Content/SoundData/SoundData.txt");
            // Parse the SoundData file
            while ((line = file2.ReadLine()) != null)
            {
                lines.Add(line);
                if (line.Contains(",") && i == 0)
                {
                    split = line.Split(',');
                    name = split[0];
                    numSounds = int.Parse(split[1]);
                    _numSounds = numSounds;
                    i = 1;
                }
                else if (i == 1 && line.Contains(",") == false)
                {
                    dataString = line;
                    tempSound = Content.Load<SoundEffect>(dataString);
                    tempSounds.Add(tempSound);
                    if (sounds.ContainsKey(name) == false)
                        sounds.Add(name, tempSounds);
                    _numSounds--;
                    if (_numSounds == 0)
                    {
                        ContentManager.CreateSound(sounds[name], name);
                        tempTextures.Clear();
                        i = 0;
                    }
                }
            }
            file2.Close();
            // Initialize Keyboard states
            KBState = new KeyboardState();
            oldKBState = new KeyboardState();
        }

        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // Update the current keyboard state
            KBState = Keyboard.GetState();
            // Call the update function passing it gameTime
            ObjectHandler.Update(gameTime);
            // Update the old keyboard state
            oldKBState = KBState;

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // Call draw function passing it spriteBatch
            ObjectHandler.Draw(spriteBatch);
            base.Draw(gameTime);
        }


    }
}
