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
using System.Linq;
#endregion

namespace GladiatorProject
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
#endif
}
