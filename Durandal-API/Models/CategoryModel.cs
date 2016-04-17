using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Durandal_API.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaxRate { get; set; }
        public string Tags { get; set; }

        public List<String> GetTags()
        {
            return this.Tags.Split(',').ToList();
        }

        public void SetTags(List<String> tags)
        {
            this.Tags = string.Join(",", tags);
        }
    }
}