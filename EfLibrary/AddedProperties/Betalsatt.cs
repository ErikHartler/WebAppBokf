using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Betalsatt
    {
      
        private enum BetalsattValueStorage { Postgiro,Bankgiro}
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var betalsatt = new List<Betalsatt>();
            foreach (var role in Enum.GetValues<BetalsattValueStorage>())
            {
               var valueToAdd = new Betalsatt { Kod =role.ToString(),Beskrivning = role.ToString() };
               betalsatt.Add(valueToAdd);
            }
            modelBuilder.Entity<Betalsatt>().HasData(betalsatt);
            Console.WriteLine($"Added {betalsatt.Count} betalsatt");
        }
    }
}
