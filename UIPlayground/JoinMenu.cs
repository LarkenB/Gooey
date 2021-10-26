using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gooey;
using Gooey.UIElements;
using Raylib_cs;
using System.Numerics;

namespace UIPlayground
{
    class JoinMenu : UIVContainer
    {
        public JoinMenu()
        {
            Content = new List<UIElement>()
            {
                new UIVContainer()
                {
                    Content =
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
                            Padding = Vector2.Zero,
                        },
                        new UIHContainer()
                        {
                            Content =
                            {
                                new UILabel()
                                {
                                    Text = "IP:",
                                    Color = Color.DARKGRAY
                                },
                                new UITextLine()
                                {
                                    Length = 100
                                }
                            },
                            Spacing = 10,
                            Padding = Vector2.Zero
                        },
                    },
                    Alignment = HorizontalAlignment.Left,
                    Spacing = 10
                },
                new UIButton
                {
                    Content = new UILabel() { Text = "Back" },
                    OnClick = () => { (Parent as UIScreen).Content = new MultiplayerMenu(); },
                    Size = new Vector2(150, 30)
                },
            };
        }
    }
}
