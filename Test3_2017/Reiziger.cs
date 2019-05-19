using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_2017
{
    class Reiziger : Passagier
    {
        public string Telefoon { get; set; }
        public List<Medereiziger> lstMedereiziger = new List<Medereiziger>();

        public Reiziger(string nm, string gsl, string telef): base(nm,gsl)
        {
            Telefoon = telef;
        }

        public override string ToString()
        {
            return $"{Name} ({Geslacht}) Telefoon: {Telefoon}";
        }

        public override string ToStringForFile()
        {
            string text = $"R;{Name};{Geslacht};{Telefoon}";
            return text;
        }
    }
}
