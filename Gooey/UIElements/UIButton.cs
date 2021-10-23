using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Gooey.UIElements
{
    class UIButton : UIHolder
    {
        public Vector2 Size = new Vector2(100, 10);
        public Color Color = Color.DARKGRAY;
        public bool isFocused { get; private set; } = false;
        public Action OnClick;

        public override Rectangle Bounds()
        {
            if (Content != null)
            {
                Rectangle cBounds = Content.Bounds();
                Rectangle bounds = new Rectangle(Position.X, Position.Y, 2 * Padding.X, 2 * Padding.Y);
                if (Size.X < cBounds.width)
                    bounds.width += cBounds.width;
                else
                    bounds.width += Size.X;
                if (Size.Y < cBounds.height)
                    bounds.height += cBounds.height;
                else
                    bounds.height += Size.Y;
                return bounds;
            }
            else
                return base.Bounds();
        }

        public override void Update()
        {
            if (CheckCollisionPointRec(GetMousePosition(), Bounds()))
                isFocused = true;
            else
                isFocused = false;

            if (isFocused && IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON) && OnClick != null)
                OnClick.Invoke();

            base.Update();
        }

        public override void Draw()
        {
            Color color = isFocused ? Fade(Color, 0.5f) : Color;
            DrawRectangleRec(Bounds(), color);
            base.Draw();
        }
    }
}
