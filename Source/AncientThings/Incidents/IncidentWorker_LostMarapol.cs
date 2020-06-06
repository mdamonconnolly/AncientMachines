using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using UnityEngine;

namespace AncientThings
{
    class IncidentWorker_LostMarapol : IncidentWorker
    {
        //TODO: Find out what this is and if i need to change it.
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            return base.CanFireNowSub(parms);
        }

        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;
            IntVec3 intvec = DropCellFinder.RandomDropSpot(map);
            
            if(!this.TryFindEntryCell(map, out intvec))
            {
                return false;
            }

            PawnKindDef marapol = PawnKindDef.Named("AM_Marapol");
            int stayTime = Rand.RangeInclusive(90000, 150000);
            IntVec3 invalid = IntVec3.Invalid;

            if(!RCellFinder.TryFindRandomCellOutsideColonyNearTheCenterOfTheMap(intvec, map, 10.0f, out invalid))
            {
                invalid = IntVec3.Invalid;
            }

            Pawn pawn = null;


            IntVec3 location = CellFinder.RandomClosewalkCellNear(intvec, map, 10, null);
            pawn = PawnGenerator.GeneratePawn(marapol, null);
            GenSpawn.Spawn(pawn, location, map, Rot4.Random, WipeMode.Vanish, false);

            //TODO: Fill inventory with random gear based on age of colony.
            pawn.TryGetComp<CompHauler>().addToCargo(ThingMaker.MakeThing(ThingDef.Named("AM_AncientBuriedChunk")));

            pawn.mindState.exitMapAfterTick = (Find.TickManager.TicksGame + stayTime);

            if(invalid.IsValid)
            {
                pawn.mindState.forcedGotoPosition = CellFinder.RandomClosewalkCellNear(invalid, map, 10, null);
            }

            Find.LetterStack.ReceiveLetter("LetterLabelLostMarapol".Translate(marapol.label.CapitalizeFirst()), "LetterLostMarapol".Translate(marapol.label), LetterDefOf.PositiveEvent, pawn, null, null);
            return true;
        }


        private bool TryFindEntryCell(Map map, out IntVec3 cell)
        {
            return RCellFinder.TryFindRandomPawnEntryCell(out cell, map, CellFinder.EdgeRoadChance_Animal + 0.2f);
        }

    }
}
