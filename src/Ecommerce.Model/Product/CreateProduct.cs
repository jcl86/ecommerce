﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Model
{
    public class CreateProduct
    {
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Product description max length is {0}")]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
