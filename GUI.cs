using SDL2;
namespace GBSharp;

public class GUI {
    public IntPtr Window;
    public IntPtr Renderer;
    public uint ScaleFactor;
    public IntPtr ScreenRenderTexture;

    private SDL.SDL_Rect _rect;

    public GUI(uint scaleFactor = 1) {
        ScaleFactor = scaleFactor;
        Window = SDL.SDL_CreateWindow("GBSharp", 0, 0, 144*(int)ScaleFactor, 160*(int)ScaleFactor, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        Renderer = SDL.SDL_CreateRenderer(Window, 0, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
        ScreenRenderTexture = SDL.SDL_CreateTexture(Renderer, SDL.SDL_PIXELFORMAT_RGBA8888, (int) SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET, 144, 160);
    }

    public void ShowMainWindow() {
        SDL.SDL_ShowWindow(Window);
    }

    public void Loop() {
        Random rnd = new Random();
        
        SDL.SDL_RenderClear(Renderer);
        for (int i = 0; i < 160*ScaleFactor; i += (int) ScaleFactor) {
            for (int j = 0; j < 144*ScaleFactor; j += (int) ScaleFactor) {
                byte red = (byte)rnd.Next(0,255), blue = (byte)rnd.Next(0,255), green = (byte)rnd.Next(0,255);
                SDL.SDL_SetRenderDrawColor(Renderer, red, blue, green, 0xFF);
                for (int ii = 0; i < ScaleFactor; ii++) {
                    for (int jj = 0; i < ScaleFactor; jj++) {
                        SDL.SDL_RenderDrawPoint(Renderer, jj, ii);
                    }
                }
            }
        }
        SDL.SDL_RenderPresent(Renderer);
    }

    public void Quit() {
        SDL.SDL_DestroyRenderer(Renderer);
        SDL.SDL_DestroyWindow(Window);
        SDL.SDL_Quit();
    }
}