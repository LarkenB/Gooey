using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace UIPlayground.UIElements
{
    class UIButton : UIElement
    {
        private UIElement _content;
        public UIElement Content
        {
            get { return _content; }
            set
            {
                _content = value;
                if (value != null)
                    value.Parent = this;
            }
        }

        public Color Color = Color.DARKGRAY;
        public bool isFocused { get; private set; } = false;
        public Action OnClick;

        public override Rectangle Bounds()
        {
            if (Content != null)
            {
                Rectangle cBounds = Content.Bounds();
                return new Rectangle(Position.X, Position.Y, cBounds.width + 2 * Padding.X, cBounds.height + 2 * Padding.Y);
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

            Content.Update();

            base.Update();
        }

        public override void Draw()
        {
            Color color = isFocused ? Fade(Color, 0.5f) : Color;

            DrawRectangleRec(Bounds(), color);

            if (Content != null)
            {
                Content.Position = Position + Padding;
                Content.Draw();
            }
            base.Draw();
        }
    }
}
