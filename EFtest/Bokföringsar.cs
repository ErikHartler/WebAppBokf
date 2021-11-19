using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Bokföringsar
    {
        public string Bokforingsar { get; set; } = null!;
        public DateTime? Start { get; set; }
        public DateTime? Slut { get; set; }
        public bool OmStangt { get; set; }
    }
}
