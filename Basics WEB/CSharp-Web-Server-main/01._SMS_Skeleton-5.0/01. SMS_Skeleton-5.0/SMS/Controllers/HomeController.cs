using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using System.Collections.Generic;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IProductService productService;
        //private readonly IProductService productService;

        public HomeController(
            Request request,
            IUserService _userService, 
            IProductService _productService)
            : base(request)
        {
            userService = _userService;
            productService = _productService;
        }

        public Response Index()
        {
      
            if (User.IsAuthenticated)
            {
                string userName = userService.GetUsername(User.Id);
                var model = new
                {
                    Username = userName,
                    IsAuthenticated = true,
                    Products = productService.GetProducts()
                };

                return View(model, "/Home/IndexLoggedIn");
            }
           
            return this.View(new { IsAuthenticated=false});
        }
    }
}







