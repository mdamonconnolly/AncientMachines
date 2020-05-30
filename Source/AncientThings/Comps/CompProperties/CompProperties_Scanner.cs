using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

namespace AncientThings
{

    class CompProperties_Scanner : CompProperties
    {

        public int scanRange = 2;
        public int scanSpeed = 2;
        public CompProperties_Scanner()
        {
            this.compClass = typeof(CompScanner);
        }
    }
}
