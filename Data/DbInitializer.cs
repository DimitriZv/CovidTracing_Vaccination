using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project334.Models;

namespace Project334.Data
{
    public class DbInitializer
    {
        public static void Initialize(Project334Context context)
        {
            // Look for any VisitorsCheckIn or VisitorsCheckOut activity.
            if (context.VisitorsCheckIn.Any() || context.VisitorsCheckOut.Any())
            {
                return;   // DB has been seeded
            }

            var visitorCheckIns = new VisitorCheckIn[]
            {
                new VisitorCheckIn{MobilePhone="0490017003",LastName="Zvolinskii",FirstMidName="Dmitrii",Email="dz@zv.zv",CheckIn=DateTime.Parse("17/04/2021 2:55:00 AM")},
                new VisitorCheckIn{MobilePhone="0492111119",LastName="Carsos",FirstMidName="Olexander",Email="co@co.com",CheckIn=DateTime.Parse("17/04/2021 12:25:00 AM")},
                new VisitorCheckIn{MobilePhone="0492111111",FirstMidName="Carson",LastName="Alexander",Email="ca@ca.ca",CheckIn=DateTime.Parse("15/04/2021 1:58:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111112",FirstMidName="Meredith",LastName="Alonso",Email="ma@ma.ma",CheckIn=DateTime.Parse("14/04/2021 8:58:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111113",FirstMidName="Arturo",LastName="Anand",Email="aa@aa.aa",CheckIn=DateTime.Parse("12/04/2021 10:38:00 AM")},
                new VisitorCheckIn{MobilePhone="0492111114",FirstMidName="Gytis",LastName="Barzdukas",Email="gb@gb.gb",CheckIn=DateTime.Parse("11/04/2021 3:15:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111115",FirstMidName="Yan",LastName="Li",Email="yl@yl.yl",CheckIn=DateTime.Parse("10/04/2021 6:45:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111116",FirstMidName="Peggy",LastName="Justice",Email="pj@pj.pj",CheckIn=DateTime.Parse("15/04/2021 12:22:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111117",FirstMidName="Laura",LastName="Norman",Email="ln@ln.ln",CheckIn=DateTime.Parse("11/04/2021 7:45:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111118",FirstMidName="Nino",LastName="Olivetto",Email="no@no.no",CheckIn=DateTime.Parse("10/04/2021 1:33:00 PM")}
            };

            context.VisitorsCheckIn.AddRange(visitorCheckIns);
            context.SaveChanges();

            var visitorCheckOuts = new VisitorCheckOut[]
            {
                new VisitorCheckOut{MobilePhone="0490017003",LastName="Zvolinskii",FirstMidName="Dmitrii",Email="dz@zv.zv",CheckOut=DateTime.Parse("17/04/2021 4:55:00 AM")},
                new VisitorCheckOut{MobilePhone="0492111119",LastName="Carsos",FirstMidName="Olexander",Email="co@co.com",CheckOut=DateTime.Parse("17/04/2021 3:25:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111111",FirstMidName="Carson",LastName="Alexander",Email="ca@ca.ca",CheckOut=DateTime.Parse("15/04/2021 3:58:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111112",FirstMidName="Meredith",LastName="Alonso",Email="ma@ma.ma",CheckOut=DateTime.Parse("14/04/2021 10:58:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111113",FirstMidName="Arturo",LastName="Anand",Email="aa@aa.aa",CheckOut=DateTime.Parse("12/04/2021 11:38:00 AM")},
                new VisitorCheckOut{MobilePhone="0492111114",FirstMidName="Gytis",LastName="Barzdukas",Email="gb@gb.gb",CheckOut=DateTime.Parse("11/04/2021 6:15:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111115",FirstMidName="Yan",LastName="Li",Email="yl@yl.yl",CheckOut=DateTime.Parse("10/04/2021 8:45:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111116",FirstMidName="Peggy",LastName="Justice",Email="pj@pj.pj",CheckOut=DateTime.Parse("15/04/2021 4:22:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111117",FirstMidName="Laura",LastName="Norman",Email="ln@ln.ln",CheckOut=DateTime.Parse("11/04/2021 9:45:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111118",FirstMidName="Nino",LastName="Olivetto",Email="no@no.no",CheckOut=DateTime.Parse("10/04/2021 2:33:00 PM")}
            };

            context.VisitorsCheckOut.AddRange(visitorCheckOuts);
            context.SaveChanges();

            var businessActivities = new BusinessActivity[]
            {
                new BusinessActivity{WorkingDate=DateTime.Parse("10/04/2021 2:33:00 PM")}
            };

            context.BusinessActivities.AddRange(businessActivities);
            context.SaveChanges();
        }
    }
}