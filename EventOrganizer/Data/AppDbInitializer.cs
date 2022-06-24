using EventOrganizer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace EventOrganizer.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Events
                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event()
                        {
                            Price = 50,
                            Name = "Küreking",
                            ImageURL = "https://media.istockphoto.com/photos/close-up-of-mens-rowing-team-picture-id163915213?k=20&m=163915213&s=612x612&w=0&h=JFmsMBORvLmbzMvQU3c0Xtm7ln4y-yzuSpFX-7Y4Qfw=",
                            Description = "Hadi bakalım kürek çekiyoruz 15 Haziran 2022 Saat 17:30",
                            EventCategory = Enums.EventCategory.Sports
                        }
                    });
                    context.SaveChanges();  
                }
            }
        }
    }
}
