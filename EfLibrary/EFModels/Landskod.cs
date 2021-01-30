using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Landskod")]
    public partial class Landskod
    {
        public Landskod()
        {
            Leverantors = new HashSet<Leverantor>();
        }

        [Key]
        [Column("Landskod")]
        [StringLength(5)]
        public string Landskod1 { get; set; }
        [StringLength(50)]
        public string Land { get; set; }

        [InverseProperty(nameof(Leverantor.LandNavigation))]
        public virtual ICollection<Leverantor> Leverantors { get; set; }
    }
}
