﻿using System.ComponentModel.DataAnnotations;

namespace EventOrganizer.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Event Event { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    
        
    }
}
