using Raylib_cs;
using static Raylib_cs.Raylib;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace UIPlayground.UIElements
{
    class UITextLine : UIElement
    {
        public uint MaxChars = 10;
        public string Text { get; private set; } = "";
        public int FontSize = 20;
        public int Length = 200;
        public Color Color = Color.DARKGRAY;
        public bool isFocused { get; private set; } = false;

        private bool _wasBackspacing = false;
        private int _backspaceFrameCount = 0;
        private int _framesCounter = 0;

        public override Rectangle Bounds()
        {
            return new Rectangle(Position.X, Position.Y, Length + 2 * Padding.X, FontSize + 2 * Padding.Y);
        }

        public override void Update()
        {
            if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
            {
                if (CheckCollisionPointRec(GetMousePosition(), Bounds()))
                {
                    isFocused = true;
                }
                else
                {
                    isFocused = false;
                    _framesCounter = 0;
                }
            }

            if (isFocused)
            {
                int key = GetCharPressed();

                while (key > 0) // Get all queued keys
                {
                    // NOTE: Only allow keys in range [32..125]
                    if ((key >= 32) && (key <= 125) && (MeasureText(Text + "_", FontSize) + FontSize / 10 < Bounds().width - 2 * Padding.X))
                        Text += (char)key;

                    key = GetCharPressed();  // Check next character in the queue
                }

                if (IsKeyDown(KeyboardKey.KEY_BACKSPACE))
                {
                    _wasBackspacing = true;
                    if (Text.Length != 0)
                    {
                        if (_wasBackspacing)
                        {
                            if (_backspaceFrameCount % 20 == 0)
                                Text = Text.Remove(Text.Length - 1);
                        }
                        else
                            Text = Text.Remove(Text.Length - 1);
                    }
                    _backspaceFrameCount++;
                }
                else
                {
                    _wasBackspacing = false;
                    _backspaceFrameCount = 0;
                }

                _framesCounter++;
            }



            base.Update();
        }

        public override void Draw()
        {
            DrawRectangleRec(Bounds(), Color);
            DrawTextRec(GetFontDefault(), Text, new Rectangle(Position.X + Padding.X, Position.Y + Padding.Y, Bounds().width - 2 * Padding.X, Bounds().height - 2 * Padding.Y), FontSize, FontSize / 10, false, Color.WHITE);
            if (isFocused)
            {
                if (((_framesCounter / 40) % 2) == 0) 
                    DrawText("_", (int)(Position.X + Padding.X + FontSize / 10 + MeasureText(Text, FontSize)), (int)(Position.Y + Padding.Y), FontSize, Color.WHITE);
            }
            base.Draw();
        }
    }
}
