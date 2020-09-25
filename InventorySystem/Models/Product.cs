using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventorySystem.Models
{
    [Table("product")]
    public partial class Product
    {
        /*


Product must have a “Quantity” that is  greater than or equal to zero
Product must have an “IsDiscontinued” boolean

         */

        // Product must have unique product “ID”
        [Key]
        [Column("id", TypeName = "int(10)")]
        public int ID { get; set; }

        // Product must have a product “Name”
        [Column("name", TypeName = "varchar(30)")]
        [Required]
        public string Name { get; set; }

        // Product must have a “Quantity” that is  greater than or equal to zero
        [Column("quantity", TypeName = "int(10)")]
        [Required]
        public int Quantity { get; set; }

        // Product must have an “IsDiscontinued” boolean
        // Set to false by default
        [Column("is_discontinued", TypeName = "tinyint(0)")]


    }
}
