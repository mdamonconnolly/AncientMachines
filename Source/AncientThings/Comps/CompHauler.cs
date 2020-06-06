using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

/*
 * TODO: How do i make it drop the cargo on death?
 * TODO: The manage container should be separate from hauler? "containers" can be their own inanimate thing.
 */

namespace AncientThings
{
    class CompHauler : ThingComp
    {
        protected List<Thing> cargo = new List<Thing>();
        private Job job_loadHauler;

        public CompProperties_Hauler Props
        {
            get
            {
                return (CompProperties_Hauler)this.props;
            }
        }

        public int carryCapacity
        {
            get
            {
                return (int)this.carryCapacity;
            }
        }


        //Set up float menu options
        public override IEnumerable<FloatMenuOption> CompFloatMenuOptions(Pawn pawn)
        {
            if(this.job_loadHauler == null)
            {
                this.job_loadHauler = new Job(DefDatabase<JobDef>.GetNamed("AM_ManageContainer", true), (LocalTargetInfo)((Thing)this.parent));
            }

            //TODO: Set up refusal gates.

            Action action = (Action)(() =>
            {
                pawn.jobs.StopAll();
                pawn.jobs.TryTakeOrderedJob(job_loadHauler);
            });

            FloatMenuOption item = new FloatMenuOption(Translator.Translate("AM_LoadHauler"), action, (MenuOptionPriority)4, null, null, 0f, null, null);

            return new List<FloatMenuOption>
            {
                item
            };
        }


        public void addToCargo(Thing thing)
        {
            cargo.Add(thing);
            
            //If thing exists in world.
            if(thing.Spawned)
            {
                thing.DeSpawn(DestroyMode.Vanish);
            }
        }

        public void dropCargo()
        {
            foreach(Thing cargo_thing in cargo)
            {
                IntVec3 intvec;
                CellFinder.TryFindRandomCellNear(this.parent.Position, this.parent.Map, 2, null, out intvec);

                GenSpawn.Spawn(ThingMaker.MakeThing(cargo_thing.def), intvec, this.parent.Map);
            }
        }
    }
}
