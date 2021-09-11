﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models
{
    public class CartDetails
    {

        public int CardDetailsId { get; set; }
        public int CardHeaderId { get; set; }
        [ForeignKey("CardHeaderId")]
        public virtual CartHeader CartHeader  { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}
