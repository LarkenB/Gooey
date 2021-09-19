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
        private static List<UIElement> elements = new List<UIElement>();

        public static void Initialize()
        {
            elements.Add(new UIVContainer
            {
                Content = {
                    new UIHContainer()
                    {
                        Content = {
                            new UITextLine()
                            {
                                Padding = new Vector2(10, 10),
                                ShowBounds = true,
                            },
                            new UIButton
                            {
                                Padding = new Vector2(25, 10),
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Hello" },
                                OnClick = () => { Console.WriteLine("Hello"); }
                            },
                            new UIButton
                            {
                                Padding = new Vector2(90, 10),
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Boo" }
                            },
                            new UIButton
                            {
                                Padding = new Vector2(50, 10),
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Hi" }
                            },
                        },
                        Spacing = 10,
                        ShowBounds = true
                    },
                    new UIHContainer()
                    {
                        Content = {
                            new UIButton
                            {
                                Padding = new Vector2(100, 10),
                                ShowBounds = true,
                                Content = new UILabel() { Text = "OOF" }
                            },
                            new UIButton
                            {
                                Padding = new Vector2(25, 69),
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Hello" }
                            },
                            new UIButton
                            {
                                Padding = new Vector2(90, 10),
                                ShowBounds = true,
                                Content = new UILabel() { Text = "Boo" }
                            },
                            new UIButton
                            {
                                Padding = new Vector2(50, 10),
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
            });
        }

        public static void Update()
        {
            for (int i = 0; i < elements.Count; i++)
                elements[i].Update();
        }

        public static void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.LIGHTGRAY);

            for (int i = 0; i < elements.Count; i++)
                elements[i].Draw();

            DrawFPS(0, 0);

            EndDrawing();
        }
    }
}
