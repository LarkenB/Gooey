using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace UIPlayground.UIElements
{
    class UILabel: UIElement
    {
        public string Text;
        public int FontSize = 20;
        public Color Color = Color.WHITE;
        public new Vector2 Padding = Vector2.Zero;

        public override Rectangle Bounds()
        {
            return new Rectangle(Position.X, Position.Y, MeasureText(Text, FontSize) + 2 * Padding.X, FontSize + 2 * Padding.Y);
        }

        public override void Draw()
        {
            DrawText(Text, (int)(Position.X + Padding.X), (int)(Position.Y + Padding.Y), FontSize, Color);
            base.Draw();
        }
    }
}
