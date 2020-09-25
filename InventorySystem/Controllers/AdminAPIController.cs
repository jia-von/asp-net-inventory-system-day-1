using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    // localhost:PORT/Admin/.....
    [Route("Product")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        // Return everything 
        [HttpGet("API/All")]

        public ActionResult<IEnumerable<Product>> AllProduct_GET()
        {
            return new ProductController().ShowInventory();
        }
    }
}
