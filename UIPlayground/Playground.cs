using System;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;
using UIPlayground.UIElements;
using System.Numerics;

namespace UIPlayground
{
    static class Playground
    {
        private static UIScreen Screen = new UIScreen();

        public static void Initialize()
        {
            Screen.Alignment = new Alignment { Horizontal = HorizontalAlignment.Right, Vertical = VerticalAlignment.Bottom };
            Screen.Padding = new Vector2(10);
            Screen.Content =
            new UIVContainer
            {
                Content = {
                    new UIHContainer
                    {
                        Content = {
                            new UITextLine
                            {
                                Padding = new Vector2(10, 10),
                                ShowBounds = true,
                            },
                            new UIButton
                            {
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Helloooooooooooooooooooooooooooooooooooooo" },
                                OnClick = () => { Console.WriteLine("Hello"); },
                                Size = new Vector2(100, 300)
                            },
                            new UIButton
                            {
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Boo" }
                            },
                            new UIButton
                            {
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Hi" }
                            },
                        },
                        Spacing = 10,
                        ShowBounds = true,
                        Alignment = VerticalAlignment.Top
                    },
                    new UIHContainer()
                    {
                        Content = {
                            new UIButton
                            {
                                ShowBounds = true,
                                Content = new UILabel() { Text = "OOF" }
                            },
                            new UIButton
                            {
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Hello" },
                                Alignment = new Alignment { Horizontal = HorizontalAlignment.Center, Vertical = VerticalAlignment.Bottom }
                            },
                            new UIButton
                            {
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Boo" }
                            },
                            new UIButton
                            {
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Hi" }
                            },
                        },
                        Spacing = 10,
                        ShowBounds = true
                    }
                },
                Spacing = 20,
                ShowBounds = true,
                Position = new Vector2(100)
            };
        }

        public static void Update()
        {
            Screen.Update();
        }

        public static void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.LIGHTGRAY);

            Screen.Draw();

            DrawFPS(0, 0);

            EndDrawing();
        }
    }
}
