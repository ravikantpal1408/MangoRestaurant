using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mango.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Mango.Web.Services.IService;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _product;

        public HomeController(ILogger<HomeController> logger, IProductService product)
        {
            _logger = logger;
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var list = new List<ProductDto>();
            var response = await _product.GetAllProductAsync<ResponseDto>(accessToken);
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

       
        [Authorize]
        public async Task<IActionResult> Details(int productId)
        {
            ProductDto model = new();
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var response = await _product.GetProductByIdAsync<ResponseDto>(productId, accessToken);
            if (response != null && response.IsSuccess)
            {
                model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

    }
}
