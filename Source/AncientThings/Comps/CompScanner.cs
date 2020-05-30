using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using System.Runtime.CompilerServices;

namespace AncientThings
{
    class CompScanner : ThingComp
    {

        public override void Initialize(CompProperties props)
        {
            this.props = props;
        }

        private void calculate()
        {
            //main logic that calls the jobdriver
        }
        private bool isReadyToScan()
        {
            //Determine if the bot is ready to scan something

            return true;
        }

        private Thing pickTarget()
        {
            return (Thing)null;
        }

        public CompProperties_Scanner Props
        {
            get
            {
                return (CompProperties_Scanner)this.props;
            }
        }

        protected int scanSpeed
        {
            get
            {
                return Props.scanSpeed;
            }
        }
        protected int scanRange
        {
            get
            {
                return Props.scanRange;
            }
        }
    }
}
