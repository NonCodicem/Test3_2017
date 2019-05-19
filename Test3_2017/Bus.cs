using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3_2017
{
    class Bus
    {
        public string Name { get; set; }
        public List<Chauffeur> lstChauffeurs { get; set; } = new List<Chauffeur>();
        public List<Gids> lstGids { get; set; } = new List<Gids>();
        public List<Reiziger> lstReiziger { get; set; } = new List<Reiziger>();
       // public List<Medereiziger> lstMedereiziger { get; set; } = new List<Medereiziger>();

        public Bus(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }    
}
