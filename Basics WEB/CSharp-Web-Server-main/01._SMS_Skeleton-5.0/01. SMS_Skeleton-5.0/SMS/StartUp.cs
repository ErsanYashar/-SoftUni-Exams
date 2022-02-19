namespace SMS
{
    using System.Threading.Tasks;
    using BasicWebServer.Server;
    using BasicWebServer.Server.Routing;
    using MyWebServer;
    using Sms.Data.Common;
    using SMS.Contracts;
    using SMS.Data;
    using SMS.Services;

    //using MyWebServer.Controllers;
    //using MyWebServer.Results.Views;

    public class StartUp
    {
        public static async Task Main()
        {
            var server = new HttpServer(routes => routes
              .MapControllers()
              .MapStaticFiles());

            server.ServiceCollection
                .Add<IUserService, UserService>()
                .Add<SMSDbContext>()
                .Add<IRepository, Repository>()
                .Add<IValidationService, ValidationService>()
                .Add<IProductService, ProductService>()
                .Add<ICartService, CartService>();

            await server.Start();
        }
           
    }
}