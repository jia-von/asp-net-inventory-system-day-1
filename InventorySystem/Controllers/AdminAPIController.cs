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

        // Create an HttpPut “DiscontinueProduct” endpoint that allows the user to discontinue a product
        [HttpPut("API/DiscontinueProduct")]
        public ActionResult DiscontinueProduct_PUT(string id)
        {
            ActionResult response;
            int number;
            id = id != null ? id.Trim() : null;

            if (string.IsNullOrWhiteSpace(id))
            {
                response = StatusCode(403, "Please enter a product id.");
            }
            else
            if(!int.TryParse(id, out number))
            {
                response = StatusCode(403, "Please enter a valid format for id.");
            }
            else
            {
                try
                {
                    new ProductController().DiscontinuedProduct(int.Parse(id));
                    response = Ok(new { message = $"Successfully discontinue product with id: {id}" });
                }
                catch (ValidationException e)
                {

                    response = StatusCode(403, e.SubExceptions.Select(x => x.Message));
                }
            }

            return response;
        }

        // Create an HttpPut “AddQuantityProduct” endpoint that allows the user to add to a product’s quantity
        [HttpPut("API/AddQuantityProduct")]

        // Accepts the product ID as a parameter
        public ActionResult AddQuantityProduct_PUT(string id, string AmountAdded)
        {
            ActionResult response;

            int number;
            id = id != null ? id.Trim() : null;
            AmountAdded = AmountAdded != null ? AmountAdded.Trim() : null;

            if (string.IsNullOrWhiteSpace(id))
            {
                response = StatusCode(403, "Please enter a product id.");
            }
            else
            if (!int.TryParse(id, out number))
            {
                response = StatusCode(403, "Please enter a valid format for id.");
            }
            else
            {

                if (string.IsNullOrWhiteSpace(AmountAdded))
                {
                    response = StatusCode(403, "Please enter quantity.");
                }
                else
                if (!int.TryParse(AmountAdded, out number))
                {
                    response = StatusCode(403, "Please enter a valid format for quantity.");
                }
                else
                if (int.Parse(AmountAdded) < 0)
                {
                    // AmountAdded must be a positive integer
                    response = StatusCode(403, "The quantity has to be postive value.");
                }
                else
                {
                    try
                    {
                        new ProductController().AddQuantityProduct(int.Parse(id), int.Parse(AmountAdded));
                        response = Ok(new { message = $"Successfully added quantity of {AmountAdded} to product id {id}" });
                    }
                    catch (ValidationException e)
                    {
                        response = StatusCode(403, e.SubExceptions.Select(x => x.Message));
                    }
                }
            }

            return response;
        }

        [HttpPut("API/SubtractQuantityProduct")]

        // Create an HttpPut “SubtractQuantityProduct” endpoint that allows the user to subtract from a product’s quantity
        public ActionResult SubtractQuantityProduct_PUT(string id, string AmountSubtracted)
        {
            ActionResult response;

            int number;
            id = id != null ? id.Trim() : null;
            AmountSubtracted = AmountSubtracted != null ? AmountSubtracted.Trim() : null;

            if (string.IsNullOrWhiteSpace(id))
            {
                response = StatusCode(403, "Please enter a product id.");
            }
            else
            if (!int.TryParse(id, out number))
            {
                response = StatusCode(403, "Please enter a valid format for id.");
            }
            else
            {

                if (string.IsNullOrWhiteSpace(AmountSubtracted))
                {
                    response = StatusCode(403, "Please enter quantity.");
                }
                else
                if (!int.TryParse(AmountSubtracted, out number))
                {
                    response = StatusCode(403, "Please enter a valid format for quantity.");
                }
                else
                if (int.Parse(AmountSubtracted) < 0)
                {
                    // AmountAdded must be a positive integer
                    response = StatusCode(403, "The quantity has to be postive value.");
                }
                else
                {
                    try
                    {
                        new ProductController().SubtractQuantityProduct(int.Parse(id), int.Parse(AmountSubtracted));
                        response = Ok(new { message = $"Successfully subtracted quantity of {AmountSubtracted} to product id {id}" });
                    }
                    catch (ValidationException e)
                    {
                        response = StatusCode(403, e.SubExceptions.Select(x => x.Message));
                    }
                }
            }

            return response;
        }

    }
}