using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Gooey;
using Gooey.UIElements;
using Raylib_cs;

namespace UIPlayground
{
    class HostMenu: UIVContainer
    {
        public HostMenu()
        {
            Content = new List<UIElement>()
            {
                new UIHContainer()
                {
                    Content =
                    {
                        new UILabel()
                        {
                            Text = "Port:",
                            Color = Color.DARKGRAY
                        },
                        new UITextLine()
                        {
                            Length = 60
                        }
                    },
                    Spacing = 10,
                    Padding = Vector2.Zero
                },
                new UIButton
                {
                    Content = new UILabel() { Text = "Host" },
                    OnClick = () => {  },
                    Size = new Vector2(150, 30)
                },
                new UIButton
                {
                    Content = new UILabel() { Text = "Back" },
                    OnClick = () => { (Parent as UIScreen).Content = new MultiplayerMenu(); },
                    Size = new Vector2(150, 30)
                },
            };
            Spacing = 10;
        }
    }
}
