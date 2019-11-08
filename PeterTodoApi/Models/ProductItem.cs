using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PeterTodoApi.Models
{
    //[Table("Products")]
    public class ProductItem
    {
        [Key]
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
    }
}
