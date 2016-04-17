using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Durandal_API.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public int StorageAmount { get; set; }
        public virtual CategoryModel Category { get; set; }
    }
}