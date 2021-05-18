using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataType = Swashbuckle.AspNetCore.SwaggerGen.DataType;

namespace API_TUI.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime DateValidityStart { get; set; }
        
        public DateTime DateValidityEnd { get; set; }

    }
}
