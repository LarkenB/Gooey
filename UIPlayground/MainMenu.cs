using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Gooey;
using Gooey.UIElements;
using static Raylib_cs.Raylib;

namespace UIPlayground
{
    class MainMenu: UIVContainer
    {
        public MainMenu()
        {
            Content = new List<UIElement>() 
            {
                new UIButton
                {
                    Content = new UILabel() { Text = "Multiplayer" },
                    OnClick = () => { (Parent as UIScreen).Content = new MultiplayerMenu(); },
                    Size = new Vector2(150, 30)
                },
                new UIButton
                {
                    Content = new UILabel() { Text = "Exit" },
                    OnClick = () => { Program.ShouldClose = true; },
                    Size = new Vector2(150, 30)
                },
            };
            Spacing = 10;
        }
    }
}
