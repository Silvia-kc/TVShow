// See https://aka.ms/new-console-template for more information
using ConsoleApp;

namespace TvShow
{
    class Program
    { 
        public static async Task Main(string[] args)
        {
            Display display = new Display();
            await display.ViewMenu();
        }
    }

}
