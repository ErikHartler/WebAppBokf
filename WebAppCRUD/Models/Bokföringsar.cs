using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    public partial class Bokföringsar
    {
        [Key]
        [StringLength(4)]
        public string Bokforingsar { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Start { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Slut { get; set; }
        public bool OmStangt { get; set; }
    }
}
