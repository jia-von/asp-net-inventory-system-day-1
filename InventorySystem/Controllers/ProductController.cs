using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySystem.Models;
using InventorySystem.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace InventorySystem.Controllers
{
    public class ProductController : Controller
    {
        // Create an HttpPost “AddProduct” endpoint that allows the user to add a product to the database
        public int AddProduct(string name, string quantity, string isDiscontinued)
        {
            name = name != null ? name.Trim() : null;
            quantity = quantity != null ? quantity.Trim() : "0";
            isDiscontinued = isDiscontinued != null ? isDiscontinued.Trim().ToLower() : null;
            int createdID;

            ValidationException exception = new ValidationException();

            if(string.IsNullOrWhiteSpace(name))
            {
                exception.SubExceptions.Add(new ArgumentNullException(nameof(name), "Name of product is not provided."));
            }else
            if(name.Length> 30)
            {
                exception.SubExceptions.Add(new ArgumentOutOfRangeException(nameof(name), "The name of the product cannot be more than 30 characters long."));
            }

            try
            {
                int.Parse(quantity);

            } 
            catch (ValidationException)
            {
                exception.SubExceptions.Add(new FormatException("The quantity is not a number format"));
            }

            if(string.IsNullOrWhiteSpace(isDiscontinued))
            {
                exception.SubExceptions.Add(new ArgumentException(nameof(isDiscontinued), "Discontinuation has to be true or false."));
            }

            if(exception.SubExceptions.Count>0)
            {
                throw exception;
            }
            else
            {
                Product product;
                using (ProductContext context = new ProductContext())
                {
                    product = new Product() { Name = name, Quantity = int.Parse(quantity), IsDiscontinued = false };
                    context.Add(product);
                    context.SaveChanges();
                    createdID = product.ID;
                }
            }

            return createdID;
        }

        // Create an HttpPut “DiscontinueProduct” endpoint that allows the user to discontinue a product
        public void DiscontinuedProduct()
        {

        }

        // Create an HttpPut “AddQuantityProduct” endpoint that allows the user to add to a product’s quantity
        public void AddQuantityProduct(int quantity, int id)
        {
            Product target;
            using (ProductContext context = new ProductContext())
            {
                target = context.Products.Where(x => x.ID == id).Single();
                target.Quantity = quantity;
                context.SaveChanges();
            }
        }
    }
}


