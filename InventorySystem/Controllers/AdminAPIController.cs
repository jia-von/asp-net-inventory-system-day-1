using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySystem.Models;
using InventorySystem.Models.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    // localhost:PORT/Product/.....
    [Route("Product")]
    [ApiController]
    public class AdminAPIController : ControllerBase
    {
        // Create an HttpGet “ShowInventory” endpoint that displays the entire inventory
        [HttpGet("API/ShowInventory")]

        public ActionResult<IEnumerable<Product>> ShowInventory_GET()
        {
            return new ProductController().ShowInventory();
        }

        // Create an HttpPost “AddProduct” endpoint that allows the user to add a product to the database
        [HttpPost("API/AddProduct")]

        public ActionResult AddProduct_POST(string name, string quantity)
        {
            ActionResult response;

            try
            {
                int newID = new ProductController().AddProduct(name, quantity);
                response = Ok(new { message = $"Successfully created product {name} with quantity of {quantity}."});
            }
            catch (ValidationException e)
            {
                response = UnprocessableEntity(new { errors = e.SubExceptions.Select(x => x.Message) });
            }

            return response;
        }
    }
}
