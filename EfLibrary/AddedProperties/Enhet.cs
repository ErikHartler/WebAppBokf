using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Enhet
    {
      
        private enum EnhetValueStorage { Timmar,Totalt}
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var enheter = new List<Enhet>();
            foreach (var role in Enum.GetValues<EnhetValueStorage>())
            {
               var valueToAdd = new Enhet { Enhet1 =role.ToString(),Beskrivning = role.ToString() };
               enheter.Add(valueToAdd);
            }
            modelBuilder.Entity<Enhet>().HasData(enheter);
            Console.WriteLine($"Added {enheter.Count} enheter");
        }
    }
}
