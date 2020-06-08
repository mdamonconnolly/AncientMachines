using System;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace AncientThings
{
    class CompHybridTether : ThingComp
    {

        public CompProperties_HybridTether Props
        {
            get
            {
                return (CompProperties_HybridTether)this.props;
            }
        }
    }
}
