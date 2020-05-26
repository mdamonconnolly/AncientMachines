using System;
using UnityEngine;
using Verse;
using RimWorld;
using Verse.AI;

namespace AncientThings
{
    public class IncidentWorker_StrangeChunk : IncidentWorker
    {

        //TODO: Find out what this is and if i need to change it
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms);
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            IntVec3 IntVec = DropCellFinder.RandomDropSpot(map);
            LookTargets lookie = new LookTargets(IntVec, map);

            Thing thing = GenSpawn.Spawn(ThingMaker.MakeThing(ThingDef.Named("AM_AncientBuriedChunk"), null), IntVec, map, WipeMode.FullRefund);

            Find.LetterStack.ReceiveLetter("LetterLabelStrangeChunk".Translate(), "LetterStrangeChunk".Translate(), LetterDefOf.NeutralEvent, lookie, null, null);
            return true;
        }
    }
}
