using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_2017
{
    abstract class Persoon
    {

        public string Name { get; }
        public string Taal { get; }

        public Persoon(string name, string taal)
        {
            Name = name;
            Taal = taal;

        }

        public abstract override string ToString();

        public abstract string ToStringForFile();

    }
}
