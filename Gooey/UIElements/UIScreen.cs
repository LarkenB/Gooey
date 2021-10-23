﻿using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Gooey.UIElements
{
    public class UIScreen : UIHolder
    {
        public override Rectangle Bounds()
        {
            return new Rectangle(0, 0, GetScreenWidth(), GetScreenHeight());
        }
    }
}
