using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_2017
{
    class Gids : Persoon
    {
        public string Telefoon { get; set; }
        public Gids(string nm, string tl, string telefoon) : base(nm, tl)
        {
            Telefoon = telefoon;
        }

        public override string ToString()
        {
            return $"{Name} ({Taal}) Telefoon: {Telefoon}";
        }

        public override string ToStringForFile()
        {
            string text = $"G;{Name};{Taal};{Telefoon}";
            return text;
        }
    }
}
