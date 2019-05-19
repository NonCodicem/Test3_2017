using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_2017
{
    class Chauffeur : Persoon
    {

        public Chauffeur(string nm, string tl) : base(nm,tl)
        {
            
        }

        public override string ToString()
        {
            return $"{Name} ({Taal})";
        }

        public override string ToStringForFile()
        {
            string text = $"C;{Name};{Taal}";
            return text;
        }

    }
}
