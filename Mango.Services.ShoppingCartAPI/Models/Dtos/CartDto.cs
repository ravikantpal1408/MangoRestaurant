using System;
using System.Collections.Generic;

namespace Mango.Services.ShoppingCartAPI.Models.Dtos
{
    public class CartDto
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
