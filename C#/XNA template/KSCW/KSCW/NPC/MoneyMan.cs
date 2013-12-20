using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSCW.NPC
{
    class MoneyMan
    {
        enum Work
        {     
            Beggar,
            //Good
            StreeMusician,
            MoneyCollector,
            MoneyCollectorWithBlade,
            MoneyCollectorWithMob,
            //Neutral
            Merchant,
            MerchantNBooth,
            Shopkeeper,
            ShoppingStreetOwner,
            //Evil
            PocketThief,
            Burglar,
            RobberWithWeapon,
            RobberWithMob
         }
        Work work;
        public MoneyMan()
        {
            work = Work.Beggar;
        }




    }
}
