using Microsoft.Extensions.DependencyInjection;

namespace Books
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = Startup.ServiceProvider.GetService<App>();

            app.Run(args);
        }
    }
}