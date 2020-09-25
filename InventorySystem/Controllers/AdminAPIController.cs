using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    // localhost:PORT/Admin/.....
    [Route("API/[controller]")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        // Create an HttpPost “AddProduct” endpoint that allows the user to add a product to the database
        [HttpPost("API/Create")]
    }
}
