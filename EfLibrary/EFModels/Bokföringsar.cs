using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfLibrary.EFModels
{
    public partial class Bokföringsar
    {
        [Display(Name = "Bokföringsår")]
        public string Bokforingsar { get; set; } = null!;

        [Display(Name = "Start")]
        public DateTime? Start { get; set; }
        [Display(Name = "Slut")]
        public DateTime? Slut { get; set; }
        [Display(Name = "Stängt?")]
        public bool OmStangt { get; set; }
    }
}
