using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EfLibrary.EFModels
{
    [Table("Personal")]
    public partial class Personal
    {
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
    }
}
