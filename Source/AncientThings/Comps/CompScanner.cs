using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;

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
    }
}
