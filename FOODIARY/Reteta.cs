using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOODIARY
{
    class Reteta
    {
       public string Nume { get; set; }
       public string img { get; set; }
       public string Descriere { get; set; }

        public override string ToString()
        {
            return Nume + Descriere;
        }
    }
}
