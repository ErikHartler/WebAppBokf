using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Enhet
    {
      
        enum EnhetValueStorage { Timmar,Totalt}
        public static void SeedData(ModelBuilder modelBuilder)
        {
            var enhet = new List<Enhet>();
            foreach (EnhetValueStorage role in Enum.GetValues(typeof(EnhetValueStorage)))
            {
               var valueToAdd = new Enhet { Enhet1 =role.ToString(),Beskrivning = role.ToString() };
               enhet.Add(valueToAdd);
            }
            modelBuilder.Entity<Enhet>().HasData(enhet);

        }
    }
}
