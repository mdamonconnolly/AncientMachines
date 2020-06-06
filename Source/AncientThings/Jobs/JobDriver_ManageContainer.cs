using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using Verse.AI;

namespace AncientThings
{
    class JobDriver_ManageContainer : JobDriver
    {
        private ThingWithComps container => job.GetTarget(TargetIndex.A).Thing as ThingWithComps;


        protected override IEnumerable<Toil> MakeNewToils()
        {
            {
                yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.ClosestTouch).FailOnDespawnedNullOrForbidden(TargetIndex.A);
            }

            {
                Toil manager = new Toil();

                manager.initAction = () =>
                {
                    container.TryGetComp<CompHauler>().dropCargo();
                };
                yield return manager;
            }
        }


        public override bool TryMakePreToilReservations(bool errorOnFailed)
        {
            return this.pawn.Reserve(this.job.targetA, job, 1, -1, null, true);
        }
    }
}
