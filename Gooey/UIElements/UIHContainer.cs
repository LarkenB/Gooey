using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Gooey.UIElements
{
    public class UIHContainer : UIContainer
    {
        public uint Spacing;
        public VerticalAlignment Alignment = VerticalAlignment.Center;

        public override Rectangle Bounds()
        {
            if (Content != null && Content.Count != 0)
            {
                Rectangle bounds = base.Bounds();
                UIElement tallest = Content[0];
                bounds.width += tallest.Bounds().width;
                for (int i = 1; i < Content.Count; i++)
                {
                    if (Content[i].Bounds().height > tallest.Bounds().height)
                        tallest = Content[i];
                    bounds.width += Content[i].Bounds().width + Spacing;
                }
                bounds.height += tallest.Bounds().height;
                bounds.x = Position.X;
                bounds.y = Position.Y;
                return bounds;
            }
            else
                return base.Bounds();
        }

        public override void Draw()
        {
            Rectangle bounds = Bounds();
            if (Content != null && Content.Count != 0)
            {
                float width = Padding.X;
                uint height = 0;
                switch (Alignment)
                {
                    case VerticalAlignment.Top:
                        height = (uint)Padding.Y;
                        break;
                    case VerticalAlignment.Center:
                        height = (uint)((bounds.height - Content[0].Bounds().height) / 2);
                        break;
                    case VerticalAlignment.Bottom:
                        height = (uint)(bounds.height - Content[0].Bounds().height - Padding.Y);
                        break;
                }
                Content[0].Position = Position + new Vector2(width, height);
                Content[0].Draw();
                width += Content[0].Bounds().width;
                for (int i = 1; i < Content.Count; i++)
                {
                    width += Spacing;
                    switch (Alignment)
                    {
                        case VerticalAlignment.Top:
                            height = (uint)Padding.Y;
                            break;
                        case VerticalAlignment.Center:
                            height = (uint)((bounds.height - Content[i].Bounds().height) / 2);
                            break;
                        case VerticalAlignment.Bottom:
                            height = (uint)(bounds.height - Content[i].Bounds().height - Padding.Y);
                            break;
                    }
                    Content[i].Position = Position + new Vector2(width, height);
                    Content[i].Draw();
                    width += Content[i].Bounds().width;
                }
            }
            base.Draw();
        }
    }
}
