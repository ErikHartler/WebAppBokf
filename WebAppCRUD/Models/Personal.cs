using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Personal
    {
        public Personal()
        {
            MenyvalPerson = new HashSet<MenyvalPerson>();
        }

        [Key]
        [StringLength(10)]
        public string Signatur { get; set; }
        [StringLength(50)]
        public string Fornamn { get; set; }
        [StringLength(50)]
        public string Efternamn { get; set; }
        [StringLength(20)]
        public string Telefonnummer { get; set; }
        [StringLength(20)]
        public string Mobiltelefon { get; set; }
        [StringLength(20)]
        public string Personalfunktion { get; set; }
        public bool IntroViaknappar { get; set; }

        [ForeignKey(nameof(Personalfunktion))]
        [InverseProperty("Personal")]
        public virtual Personalfunktion PersonalfunktionNavigation { get; set; }
        [InverseProperty("AnvandareNavigation")]
        public virtual ICollection<MenyvalPerson> MenyvalPerson { get; set; }
    }
}
