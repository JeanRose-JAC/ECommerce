using ECommerce.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Api.Order.Controllers
{
    /*
    * Course: 		Web Programming 3
    * Assessment: 	Milestone 3
    * Created by: 	JEAN ROSE MANIGBAS - 2127668
    * Date: 		11 NOV 2023
    * Class Name: 	OrdersController.cs
    * Description: 	The orders controller class handles the functions that get called when a http request is made in the website.
    */

    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;
        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }

        [HttpGet()]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await ordersProvider.GetOrdersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await ordersProvider.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}