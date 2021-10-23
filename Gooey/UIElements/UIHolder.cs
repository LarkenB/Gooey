using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Gooey.UIElements
{
    class UIHolder : UIElement
    {
        public Alignment Alignment = new Alignment { Horizontal = HorizontalAlignment.Center, Vertical = VerticalAlignment.Center };

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

        public override void Update()
        {
            Content.Update();
            base.Update();
        }

        public override void Draw()
        {
            if (Content != null)
            {
                Content.Position = Position;

                switch (Alignment.Vertical)
                {
                    case VerticalAlignment.Top:
                        Content.Position.Y += Padding.Y;
                        break;
                    case VerticalAlignment.Center:
                        Content.Position.Y += (Bounds().height - Content.Bounds().height) / 2;
                        break;
                    case VerticalAlignment.Bottom:
                        Content.Position.Y += Bounds().height - Content.Bounds().height - Padding.Y;
                        break;
                }

                switch (Alignment.Horizontal)
                {
                    case HorizontalAlignment.Left:
                        Content.Position.X += Padding.Y;
                        break;
                    case HorizontalAlignment.Center:
                        Content.Position.X += (Bounds().width - Content.Bounds().width) / 2;
                        break;
                    case HorizontalAlignment.Right:
                        Content.Position.X += Bounds().width - Content.Bounds().width - Padding.X;
                        break;
                }

                Content.Draw();
            }
            base.Draw();
        }
    }
}
