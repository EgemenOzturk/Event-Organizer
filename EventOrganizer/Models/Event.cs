using EventOrganizer.Data.Base;
using EventOrganizer.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventOrganizer.Models
{
    public class Event:IEntityBase
    {

        [Key]

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventCategory EventCategory { get; set; }
        public int Capacity { get; set; }
    }
}
