using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
          return Ok(Products);
        }
    }
}
