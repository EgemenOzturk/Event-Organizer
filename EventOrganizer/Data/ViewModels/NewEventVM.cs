using EventOrganizer.Data;
using EventOrganizer.Data.Base;
using EventOrganizer.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrganizer.Models
{
    public class NewEventVM
    {

        public int Id { get; set; }

        [Display(Name = "Event name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Event description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in ₺")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Event poster URL")]
        [Required(ErrorMessage = "Event poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Event start date")]
        [Required(ErrorMessage = "Event start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Event end date")]
        [Required(ErrorMessage = "Event end date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Event category is required")]
        public EventCategory EventCategory { get; set; }

        [Display(Name = "Event capacity")]
        [Required(ErrorMessage = "Event capacity is required")]
        public int Capacity { get; set; }
    }
}
