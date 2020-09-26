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
        public int AddProduct(string name, string quantity)
        {
            name = name != null ? name.Trim() : null;
            quantity = quantity != null ? quantity.Trim() : "0";
            int createdID;

            ValidationException exception = new ValidationException();

            if(string.IsNullOrWhiteSpace(name))
            {
                exception.SubExceptions.Add(new ArgumentNullException("Name of product is not provided."));
            }else
            if(name.Length> 30)
            {
                exception.SubExceptions.Add(new ArgumentOutOfRangeException("The name of the product cannot be more than 30 characters long."));
            }

            try
            {
                int.Parse(quantity);

            } 
            catch (ValidationException)
            {
                exception.SubExceptions.Add(new FormatException("The quantity is not a number format"));
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
        public void DiscontinuedProduct(int id)
        {
            Product target;
            ValidationException exception = new ValidationException();

            using (ProductContext context = new ProductContext())
            {
                target = context.Products.Where(x => x.ID == id).Single();

                if (target.IsDiscontinued == true)
                {
                    exception.SubExceptions.Add(new Exception("This product has already been discontinued."));
                    throw exception;
                }
                else
                {
                    target.IsDiscontinued = true;
                    context.SaveChanges();
                }
            }
        }

        // Create an HttpPut “AddQuantityProduct” endpoint that allows the user to add to a product’s quantity
        public void AddQuantityProduct(int id, int amountAdded)
        {
            Product target;
            ValidationException exception = new ValidationException();

            using (ProductContext context = new ProductContext())
            {
                target = context.Products.Where(x => x.ID == id).Single();

                if (target.IsDiscontinued == true)
                {
                    // User cannot add to a product that has been discontinued
                    exception.SubExceptions.Add(new Exception("This product has already been discontinued. Cannot add quantity. "));
                    throw exception;
                }else
                {
                    target.Quantity += amountAdded;
                    context.SaveChanges();
                }

            }
        }

        // Create an HttpPut “SubtractQuantityProduct” endpoint that allows the user to subtract from a product’s quantity
        public void SubtractQuantityProduct(int id, int amountSubtracted)
        {
            Product target;
            ValidationException exception = new ValidationException();

            using (ProductContext context = new ProductContext())
            {
                target = context.Products.Where(x => x.ID == id).Single();

                // If user attempts to subtract more than is in stock, reject the entire transaction, respond with Http Status 403 and include a descriptive message in the Content
                if (target.Quantity - amountSubtracted < 0)
                {
                    exception.SubExceptions.Add(new Exception($"The current quantity is {target.Quantity}. Cannot subtract more than this value."));
                    throw exception;
                }
                else
                {
                    target.Quantity -= amountSubtracted;
                    context.SaveChanges();
                }
            }
        }

        // Create an HttpGet “ShowInventory” endpoint that displays the entire inventory
        // Requires no parameters
        // This endpoint will not return products that have been discontinued
        // Order by “Quantity” from lowest to highest so that user will know what needs to be restocked
        public List<Product> ShowInventory()
        {
            List<Product> productList = new List<Product>();
            using(ProductContext context = new ProductContext())
            {
                productList = context.Products.Where(x => x.IsDiscontinued == false).OrderByDescending(y =>y.Quantity).ToList();
            }
            return productList;
        }
    }
}


