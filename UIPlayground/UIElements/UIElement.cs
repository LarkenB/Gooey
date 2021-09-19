using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace UIPlayground.UIElements
{
    class UIElement
    {
        public Vector2 Padding = new Vector2(10);
        public Vector2 Position = Vector2.Zero;
        public bool ShowBounds = false;
        public UIElement Parent;
        public virtual Rectangle Bounds() { return new Rectangle(0, 0, 2 * Padding.X, 2 * Padding.Y); }
        public virtual void Update() { }
        public virtual void Draw() 
        {
            Rectangle bounds = Bounds();
            if (ShowBounds)
                DrawRectangleLinesEx(Bounds(), 1, Color.RED);
        }
    }
}
