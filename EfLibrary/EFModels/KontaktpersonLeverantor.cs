using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Kontaktperson_Leverantor")]
    public partial class KontaktpersonLeverantor
    {
        public int? Leverantorsnummer { get; set; }
        public int? Radnummer { get; set; }
        [StringLength(30)]
        public string Fornamn { get; set; }
        [StringLength(30)]
        public string Efternamn { get; set; }
        [StringLength(255)]
        public string TelefonDirekt { get; set; }
        [StringLength(255)]
        public string TelefonHem { get; set; }
        [StringLength(255)]
        public string TelefonMobil { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Leverantorsnummer))]
        [InverseProperty(nameof(Leverantor.KontaktpersonLeverantors))]
        public virtual Leverantor LeverantorsnummerNavigation { get; set; }
    }
}
