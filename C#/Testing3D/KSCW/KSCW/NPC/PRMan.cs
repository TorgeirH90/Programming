using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSCW.NPC
{
    class PRMan
    {
        enum Work
        {
            Madman,
            //Good
            StreetDisturbance,
            Storyteller,
            Scholar,
            Professor,
            //Neutral
            Streetprayer,
            ReligiousManiac,
            MadPriest,
            DoomsdayProphet,
            //Evil
            Bully,
            Murderer,
            Dentist,
            Inquisitor
        };
        Work work;

        public PRMan()
        {
            work = Work.Madman;
        }

    }
}
