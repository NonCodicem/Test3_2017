using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_2017
{
    abstract class Passagier 
    {
        public string Name { get; set; }
        public string Geslacht { get; set; }

        public Passagier(string name, string geslacht)
        {
            Name = name;
            Geslacht = geslacht;
        }

        abstract public override string ToString();
        public abstract string ToStringForFile();
        

    }
}
