using Verse;
using System.Collections.Generic;

namespace AncientThings
{

    public class CompProperties_Diggable : CompProperties
    {
        public List<string> spawnables = new List<string>();
        public List<string> defenders = new List<string>();

        public CompProperties_Diggable()
        {
            this.compClass = typeof(CompDiggable);
        }
    }
}
