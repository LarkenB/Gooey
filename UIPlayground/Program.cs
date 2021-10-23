using static Raylib_cs.Raylib;
using Raylib_cs;

namespace UIPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            InitWindow(1920, 1080, "UI Playground");
            SetWindowState(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            SetTargetFPS(144);

            Playground.Initialize();

            while (!WindowShouldClose())
            {
                Playground.Update();
                Playground.Draw();
            }
        }
    }
}
