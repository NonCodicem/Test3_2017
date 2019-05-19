using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_2017
{
    class Medereiziger : Passagier
    {
        public Medereiziger(string nm, string gsl): base(nm,gsl)
        {

        }

        public override string ToString()
        {
            return $"{Name} ({Geslacht})";
        }

        public override string ToStringForFile()
        {
            string text = $"M;{Name};{Geslacht}";
            return text;
        }
    }
}
