using System;
using RimWorld;
using System.Collections.Generic;
using Verse;
using Verse.AI;

namespace AncientThings
{
    class CompDiggable : ThingComp
    {

        public List<string> itemYield = new List<string>();
        public List<string> pawnYield = new List<string>();

        private Job job_dig;

        public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(Pawn pawn)
        {

            //Set up job
            if( this.job_dig == null)
            {
                this.job_dig = new Job(DefDatabase<JobDef>.GetNamed("AM_Dig", true), (LocalTargetInfo)((Thing)this.parent));
            }

            //Gates
            if(!pawn.CanReach(this.parent, PathEndMode.InteractionCell, Danger.Some))
            {
                FloatMenuOption itemNoPath = new FloatMenuOption("CannotUserNoPath".Translate(), null);
                return new List<FloatMenuOption>
                {
                    itemNoPath
                };
            }
            if(!pawn.health.capacities.CapableOf(PawnCapacityDefOf.Manipulation))
            {
                FloatMenuOption itemNoCapacity = new FloatMenuOption("CannotUseReason".Translate("IncapableOfCapacity".Translate(PawnCapacityDefOf.Manipulation.label)), null);
                return new List<FloatMenuOption>
                {
                    itemNoCapacity
                };
            }

            Action action = (Action)(() =>
           {
               pawn.jobs.StopAll();
               pawn.jobs.TryTakeOrderedJob(job_dig, JobTag.MiscWork);
           });

            FloatMenuOption item = new FloatMenuOption(Translator.Translate("AM_Dig"), action, (MenuOptionPriority)4, null, null, 0f, null, null);

            return new List<FloatMenuOption>
            {
                item
            };
        }

        public override void Initialize(CompProperties props)
        {
            this.props = props;
            this.setOutput();
        }

        public CompProperties_Diggable Props
        {
            get
            {
                return (CompProperties_Diggable)this.props;
            }
        }

        protected List<string> spawnables
        {
            get
            {
                return this.Props.spawnables;
            }
        }

        protected List<string> defenders
        {
            get
            {
                return this.Props.defenders;
            }
        }

        protected int daysPassed
        {
            get
            {
                return (int)RimWorld.GenDate.DaysPassed;
            }
        }

        //TODO: Set an "appearance chance" for items, and a value, so that if 2 rare items appear, there will be more hybrids.
        protected void setOutput()
        {
            Log.Message("Calculating output of chunk...");

            Random rand = new Random();
            int chunkOutput = rand.Next(1, 4);
            Log.Message("Chunk output should be: " + chunkOutput + "\nGenerating...");

            for(int i = 0; i < chunkOutput; ++i)
            {
                Log.Message(i + ": ");
                int itemChoice = rand.Next(Props.spawnables.Count);
                Log.Message(Props.spawnables[itemChoice] + " being added to chunk...");
                itemYield.Add(Props.spawnables[itemChoice]);

                if(i >= 2)
                {
                    int pawnChoice = rand.Next(Props.defenders.Count);
                    Log.Message(Props.defenders[pawnChoice] + " being added to chunk...");
                    pawnYield.Add(Props.defenders[pawnChoice]);
                }

            }
        }

        public void unearth()
        {
            Log.Message("Unearthing Chunk");

            for(int i = 0; i < itemYield.Count; ++i)
            {
                Log.Message("AM_unearth: Spawning " + itemYield[i]);
                IntVec3 itemCell;
                CellFinder.TryFindRandomCellNear(this.parent.Position, this.parent.Map, 3, null, out itemCell, -1);
                GenSpawn.Spawn(ThingMaker.MakeThing(ThingDef.Named(itemYield[i]), ThingDefOf.Steel), this.parent.Position, this.parent.Map, WipeMode.FullRefund);
            }

            for(int i = 0; i < pawnYield.Count; ++i)
            {
                Log.Message("AM_unearth: Spawning " + pawnYield[i]);
                IntVec3 itemCell;
                CellFinder.TryFindRandomCellNear(this.parent.Position, this.parent.Map, 3, null, out itemCell, -1);
                PawnKindDef pawn = PawnKindDef.Named(pawnYield[i]);
                GenSpawn.Spawn(PawnGenerator.GeneratePawn(pawn, null), this.parent.Position, this.parent.Map, Rot4.Random, WipeMode.Vanish, false);
            }

            this.parent.DeSpawn(DestroyMode.Deconstruct);
        }
    }
}
