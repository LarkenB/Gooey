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
        public bool isActive { get; private set; } = false; // maybe rename to isPressed?
        public bool isFocused { get; private set; } = false;

        private bool _wasBackspacing = false;
        private int _backspaceFrameCount = 0;
        private int _framesCounter = 0;

        private bool _wasDragStarted = false;
        private Vector2 _dragStart;
        private Vector2 _dragEnd;
        private bool _wasDragFinished = false;

        public override Rectangle Bounds()
        {
            return new Rectangle(Position.X, Position.Y, Length + 2 * Padding.X, FontSize + 2 * Padding.Y);
        }

        public override void Update()
        {
            if (CheckCollisionPointRec(GetMousePosition(), Bounds()))
            {
                isFocused = true;
                if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    isActive = true;
                    _wasDragStarted = true;
                    _dragStart = GetMousePosition();
                }
            }
            else
            {
                isFocused = false;
                if (IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    isActive = false;
                    _framesCounter = 0;
                }
            }

            if (IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON) && _wasDragStarted)
            {
                if (GetMousePosition() != _dragStart)
                {
                    _wasDragStarted = false;
                    _dragEnd = GetMousePosition();
                    _wasDragFinished = true;
                }
            }
            else
                _wasDragFinished = false;

            //if (_wasDragFinished)
            //{
            //    if (Vector2.Distance(_dragStart, _dragEnd) >= 5)
            //    {
            //        Console.WriteLine("Drag event...");
            //        int startX = _dragStart.X < Position.X + Padding.X ? (int)Position.X : (int)_dragStart.X;
            //        uint deltaX = (uint)Math.Abs(_dragStart.X - _dragEnd.X);
            //        if (_dragStart.X > _dragEnd.X)
            //        {
            //            // Drag from right to left
            //            //Position.X + Padding.X
            //        }
            //        else
            //        {
            //            // Drag from left to right
            //            while (deltaX < )
            //            {
            //                if (_dragStart.X < Position.X + Padding.X)
            //            }
            //        }
            //    }
            //}

            if (isActive)
            {
                int key = GetCharPressed();

                while (key > 0) // Get all queued keys
                {
                    // NOTE: Only allow keys in range [32..125]
                    if ((key >= 32) && (key <= 125) && (MeasureText(Text + "_", FontSize) + FontSize / 10 < Bounds().width - 2 * Padding.X))
                        Text += (char)key;

                    key = GetCharPressed();  // Check next character in the queue
                }

                if (IsKeyDown(KeyboardKey.KEY_BACKSPACE)) //super simple backspacing that should be changed to behave more like common textlines
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
            Color color = isFocused ? Fade(Color, 0.5f) : Color;

            DrawRectangleRec(Bounds(), color);
            DrawTextRec(GetFontDefault(), Text, new Rectangle(Position.X + Padding.X, Position.Y + Padding.Y, Bounds().width - 2 * Padding.X, Bounds().height - 2 * Padding.Y), FontSize, FontSize / 10, false, Color.WHITE);
            if (isActive)
            {
                if (((_framesCounter / 40) % 2) == 0) 
                    DrawText("_", (int)(Position.X + Padding.X + FontSize / 10 + MeasureText(Text, FontSize)), (int)(Position.Y + Padding.Y), FontSize, Color.WHITE);
            }
            base.Draw();
        }
    }
}
