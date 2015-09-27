
using Owin;
namespace WorkViewer
{
    public static class AppBuilderExtensions
    {
        public static void UseHttpGetResource(this IAppBuilder appBuilder)
        {
            appBuilder.Use<HttpGetResourceComponent>();
        }

        public static void UseNotFound(this IAppBuilder appBuilder)
        {
            appBuilder.Use<NotFoundComponent>();
        }
    }
}
