using System;
using System.Collections.Generic;

namespace EfLibrary.EFModels
{
    public partial class Bokföringsar
    {
        public string Bokforingsar { get; set; } = null!;
        public DateTime? Start { get; set; }
        public DateTime? Slut { get; set; }
        public bool OmStangt { get; set; }
    }
}
