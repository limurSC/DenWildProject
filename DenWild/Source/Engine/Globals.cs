﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DenWild.Source.Engine
{
    public delegate void PassObject(object i);

    public class Globals
    {
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
    }
}
