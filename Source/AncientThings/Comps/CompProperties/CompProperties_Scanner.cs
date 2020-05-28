using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace AncientThings
{

    class CompProperties_Scanner : CompProperties
    {

        public int scanRange;
        public int scanSpeed;
        public CompProperties_Scanner()
        {
            this.compClass = typeof(CompScanner);
        }
    }
}
