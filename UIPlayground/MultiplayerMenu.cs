using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Gooey.UIElements;

namespace UIPlayground
{
    class MultiplayerMenu: UIVContainer
    {
        public MultiplayerMenu()
        {
            Content = new List<UIElement>() 
            {
                new UIButton
                {
                    Content = new UILabel() { Text = "Host" },
                    OnClick = () => { (Parent as UIScreen).Content = new HostMenu(); },
                    Size = new Vector2(150, 30)
                },
                new UIButton
                {
                    Content = new UILabel() { Text = "Join" },
                    OnClick = () => { (Parent as UIScreen).Content = new JoinMenu(); },
                    Size = new Vector2(150, 30)
                },
                new UIButton
                {
                    Content = new UILabel() { Text = "Back" },
                    OnClick = () => { (Parent as UIScreen).Content = new MainMenu(); },
                    Size = new Vector2(150, 30)
                },
            };
            Spacing = 10;
        }
    }
}
