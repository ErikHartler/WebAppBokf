using System;
using System.Collections.Generic;

namespace EFtest
{
    public partial class Menyval
    {
        public Menyval()
        {
            MenyvalPeople = new HashSet<MenyvalPerson>();
            MenyvalPersFunkts = new HashSet<MenyvalPersFunkt>();
        }

        public int Menyvalsnr { get; set; }
        public string? Menyval1 { get; set; }
        public string? Meny { get; set; }
        public string? Beskrivning { get; set; }
        public string? Form { get; set; }
        public string? Report { get; set; }
        public string? Query { get; set; }
        public string? ShellFunction { get; set; }

        public virtual Meny? MenyNavigation { get; set; }
        public virtual ICollection<MenyvalPerson> MenyvalPeople { get; set; }
        public virtual ICollection<MenyvalPersFunkt> MenyvalPersFunkts { get; set; }
    }
}
