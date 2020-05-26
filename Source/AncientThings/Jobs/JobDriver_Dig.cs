using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;

//TODO: Add progress bar work
//TODO: Make defender mechs spawn hostile
//TODO: Make all items spawn undeployed

namespace AncientThings
{
    class JobDriver_Dig : JobDriver
    {

        private ThingWithComps chunk => job.GetTarget(TargetIndex.A).Thing as ThingWithComps;
        private const float deconstructWork = 200f;


        protected override IEnumerable<Toil> MakeNewToils()
        {
            
            {
                yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.ClosestTouch).FailOnDespawnedNullOrForbidden(TargetIndex.A);
            }

            {
                Toil dig = new Toil();
                dig.initAction = () =>
                {
                    chunk.TryGetComp<CompDiggable>().unearth();
                };
                yield return dig;
            }
        }

        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return this.pawn.Reserve(this.job.targetA, job, 1, -1, null, true);
        }
    }
}
