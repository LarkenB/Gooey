using Raylib_cs;
using static Raylib_cs.Raylib;
using System.Numerics;

namespace Gooey.UIElements
{
    public class UIVContainer : UIContainer
    {
        public uint Spacing;

        public override Rectangle Bounds()
        {
            if (Content != null && Content.Count != 0)
            {
                Rectangle bounds = base.Bounds();
                UIElement widest = Content[0];
                bounds.height += widest.Bounds().height;
                for (int i = 1; i < Content.Count; i++)
                {
                    if (Content[i].Bounds().width > widest.Bounds().width)
                        widest = Content[i];
                    bounds.height += Content[i].Bounds().height + Spacing;
                }
                bounds.width += widest.Bounds().width;
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
                float height = Padding.Y;
                Content[0].Position = Position + new Vector2((bounds.width - Content[0].Bounds().width) / 2, height);
                Content[0].Draw();
                height += Content[0].Bounds().height;
                for (int i = 1; i < Content.Count; i++)
                {
                    height += Spacing;
                    Content[i].Position = Position + new Vector2((bounds.width - Content[i].Bounds().width) / 2, height);
                    Content[i].Draw();
                    height += Content[i].Bounds().height;
                }
            }
            base.Draw();
        }
    }
}
