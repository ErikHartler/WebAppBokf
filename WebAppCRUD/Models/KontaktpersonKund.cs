using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    [Table("Kontaktperson_Kund")]
    public partial class KontaktpersonKund
    {
        public int? Kundnummer { get; set; }
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

        [ForeignKey(nameof(Kundnummer))]
        [InverseProperty(nameof(Kund.KontaktpersonKund))]
        public virtual Kund KundnummerNavigation { get; set; }
    }
}
