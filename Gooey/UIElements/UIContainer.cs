using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Gooey.UIElements
{
    abstract class UIContainer : UIElement
    {
        private List<UIElement> _content = new List<UIElement>();
        public List<UIElement> Content 
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                if (value != null)
                    foreach (UIElement e in value)
                        e.Parent = this;
            }
        }

        public override void Update()
        {
            if (Content != null)
                foreach (UIElement e in Content)
                    e.Update();
        }
    }
}
