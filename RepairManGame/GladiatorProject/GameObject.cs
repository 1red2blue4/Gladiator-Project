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
        bool isColliding;
        bool onScreen;

        public GameObject(string nm, Vector2 pos, Rectangle htBx, Animations anmtn)
        {
            //parameters
            name = nm;
            position = pos;
            hitBox = htBx;
            animation = anmtn;

            //reference calls to other classes
            currentAnimation = animation.getSprite(name);
            sounds = ContentManager.GetSounds(name);

            isColliding = false;
            onScreen = false;
            //these two will be false by default; logic will have to determine whether they are true or false
        }


       
    }
}
