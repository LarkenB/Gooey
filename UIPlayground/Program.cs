using static Raylib_cs.Raylib;
using Raylib_cs;
using Gooey;
using Gooey.UIElements;

namespace UIPlayground
{
    class Program
    {
        public static bool ShouldClose = false;

        static void Main(string[] args)
        {
            InitWindow(1920, 1080, "UI Playground");
            SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            SetTargetFPS(144);

            UIScreen Screen = new UIScreen
            {
                Content = new MainMenu()
            };

            while (!WindowShouldClose() && !ShouldClose)
            {
                BeginDrawing();
                ClearBackground(Color.LIGHTGRAY);
                
                Screen.Update();
                Screen.Draw();

                EndDrawing();
            }
        }
    }
}
