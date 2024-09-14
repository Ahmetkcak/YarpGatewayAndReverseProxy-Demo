using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Products =
        [
            "Laptop", "Smartphone", "Tablet", "Headphones", "Smartwatch", "Camera", "Monitor", "Keyboard", "Mouse", "Printer"
        ];


        [HttpGet]
        //[OutputCache]
        public async Task<IActionResult> Get()
        {
            //await Task.Delay(4000);
            return Ok(Products);
        }
    }
}
