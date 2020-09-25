using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models.Exceptions
{
    public class ValidationException : Exception
    {
        // A list of exceptions to be thrown as one.
        public List<Exception> SubExceptions { get; set; } = new List<Exception>();

        // Override our message with a summary.
        public override string Message => $"There are {SubExceptions.Count} exceptions.";

        // When we construct this exception without a messsage, we get an empty sub-list which we can populate.
        public ValidationException() : base()
        { }

        public ValidationException(string message) : base()
        {
            // When we construct this exception with a message, it gets added to the subexceptions list.
            SubExceptions.Add(new Exception(message));
        }
    }
}
