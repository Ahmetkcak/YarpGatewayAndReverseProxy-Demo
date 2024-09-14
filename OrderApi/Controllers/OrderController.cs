using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        [HttpGet]
        //[OutputCache]
        public async Task<IEnumerable<Order>> Get()
        {
            await Task.Delay(5000);
            var orders = new List<Order>
            {
                new(1, "John Doe", "Laptop"),
                new(2, "Jane Doe", "Smartphone"),
                new(3, "Alice", "Tablet"),
                new(4, "Bob", "Headphones"),
                new(5, "Charlie", "Smartwatch"),
                new(6, "David", "Camera"),
                new(7, "Eve", "Monitor"),
                new(8, "Frank", "Keyboard"),
                new(9, "Grace", "Mouse"),
                new(10, "Heidi", "Printer")
            };
            return orders;
        }
    }
}
