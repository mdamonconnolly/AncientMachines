using RimWorld;
using Verse;
using Verse.AI;

namespace AncientThings
{
    class WorkGiver_Dig : WorkGiver_Scanner
    {

        public override PathEndMode PathEndMode => PathEndMode.Touch;

        public override Danger MaxPathDanger(Pawn pawn)
        {
            return Danger.Deadly;
        }

        public override Job JobOnThing(Pawn pawn, Thing t, bool forced = false)
        {
            if(t.def.category != ThingCategory.Item)
            {
                return null;
            }

            if(t.IsForbidden(pawn))
            {
                return null;
            }

            return null;
        }

    }
}
