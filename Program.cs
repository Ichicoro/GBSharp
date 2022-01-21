using GBSharp;
using SDL2;

// Console.WriteLine("Hello, World!");

var GUI = new GUI(2);
GUI.ShowMainWindow();

var CPU = new CPU();
CPU.PrintStatus();

SDL.SDL_Event e;
var quit = false;
while (!quit) {
    while (SDL.SDL_PollEvent(out e) != 0) {
        if (e.type == SDL.SDL_EventType.SDL_QUIT) {
            quit = true;
        }
        GUI.Loop();
    }
}

GUI.Quit();