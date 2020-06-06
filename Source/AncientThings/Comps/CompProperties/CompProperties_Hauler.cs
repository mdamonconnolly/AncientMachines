using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AncientThings
{
    class CompProperties_Hauler : CompProperties
    {
        public int carryCapacity = 20;

        public CompProperties_Hauler()
        {
            this.compClass = typeof(CompHauler);
        }
    }
}
