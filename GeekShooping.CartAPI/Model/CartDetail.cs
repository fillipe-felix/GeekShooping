﻿using System.ComponentModel.DataAnnotations.Schema;

using GeekShooping.CartAPI.Model.Base;

namespace GeekShooping.CartAPI.Model;

[Table("cart_detail")]
public class CartDetail : BaseEntity
{
    public string CartHeaderId { get; set; }

    [ForeignKey("CartHeaderId")]
    public CartHeader CartHeader { get; set; }
    
    public string ProductId { get; set; }
    
    [ForeignKey("ProductId")]
    public Product Product { get; set; }
    
    [Column("count")]
    public int Count { get; set; }
    
}