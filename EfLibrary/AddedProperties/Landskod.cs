using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Landskod
    {
      
        private enum LandskodValueStorage { Swe,Dk,No}
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var landskod = new List<Landskod>();
            foreach (var role in Enum.GetValues<LandskodValueStorage>())
            {
               var valueToAdd = new Landskod { Kod =role.ToString(), Land = role.ToString() };
               landskod.Add(valueToAdd);
            }
            modelBuilder.Entity<Landskod>().HasData(landskod);
            Console.WriteLine($"Added {landskod.Count} landskod");
        }
    }
}
