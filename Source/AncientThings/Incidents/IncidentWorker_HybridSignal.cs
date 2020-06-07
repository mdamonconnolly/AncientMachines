using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace AncientThings
{
    //All hybrids capable of combat, maddened.
    class IncidentWorker_HybridSignal_Attack : IncidentWorker
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms);
        }


        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            

            Map map = (Map)parms.target;

            foreach(Pawn p in map.mapPawns.AllPawns)
            {
                //Better to conditional from thinktree or race?
                if(p.thinker.MainThinkTree.defName == "AM_Hybrid")
                {
                    p.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.Manhunter, null, forceWake : true);
                }
            }

            Find.LetterStack.ReceiveLetter("LetterLabelHybridSignalAttack".Translate(), "LetterHybridSignalAttack".Translate(), LetterDefOf.NegativeEvent, null, null, null);
            
            return true;
        }
    }

    //All hauler hybrids in map collect any pickupable items
    class IncidentWorker_HybridSignal_Collect : IncidentWorker
    {

        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms);
        }


        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            return true;
        }

    }

    //All hybrids that eat, will eat everything in map
    class IncidentWorker_HybridSignal_Devour : IncidentWorker
    {

        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms);
        }


        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            return true;
        }

    }
}
