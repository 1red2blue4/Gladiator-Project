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
using Microsoft.Xna.Framework.Audio;
#endregion

namespace GladiatorProject
{

    /// <summary>
    /// Possible Attributes...
    ///     string name
    ///     vector2 position
    ///     rectangle hitBox
    ///     List<SoundEffect> sounds
    ///     Position in the game grid
    ///     Texture2D sprite
    ///     AnimationData currentAnimation
    ///     Animations Animation
    ///     bool canCollide
    ///     bool onScreen
    ///     ...
    /// 
    /// Possible Methods...
    ///     Paramaterized Constructor
    ///     Update
    ///     Draw
    ///     ...
    /// </summary>
    class GameObject
    {
        string name;
        Vector2 position;
        Rectangle hitBox;
        List<SoundEffect> sounds;
        Texture2D sprite;
        AnimationData currentAnimation;
        Animations animation;
        bool canCollide;
        bool onScreen;

        public GameObject(string nm, Vector2 pstn, Animations anmtn, Texture2D sprt, bool cnClld, bool nScrn)
        {
            //parameters
            name = nm;
            position = pstn;
            animation = anmtn;
            sprite = sprt;

            //Initialize a starting animation, and a hitbox based upon parameters
            currentAnimation = animation.getSprite(name);
            hitBox = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);

            //more parameters
            canCollide = false; //default false
            onScreen = false; //default false
            sounds = ContentManager.GetSounds(name);
        }

        //primary update method
        public virtual void Update()
        {

        }

        //primary draw method
        public virtual void Draw()
        {

        }

    }
}
