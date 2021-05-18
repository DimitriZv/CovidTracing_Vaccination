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
            if (context.VisitorsCheckIn.Any() || context.VisitorsCheckOut.Any() || context.DangerousCases.Any())
            {
                return;   // DB has been seeded
            }

            var dangerousCases = new DangerousCase[]
            {
                new DangerousCase{MobilePhone="0492111118",FirstMidName="Nino",LastName="Olivetto",Email="no@no.no",Sex=Sex.Male,ConfirmDate=DateTime.Parse("10/04/2021 2:55:00 AM"),HasVaccine=true, DOB=DateTime.Parse("10/04/2000 2:55:00 AM")},
                new DangerousCase{MobilePhone="0492111119",FirstMidName="Latino",LastName="Ciusino",Email="nobo@nobo.nobo",Sex=Sex.Female,ConfirmDate=DateTime.Parse("22/04/2021 10:55:00 PM"),HasVaccine=false, DOB=DateTime.Parse("10/04/1990 2:55:00 AM")}
            };
            context.DangerousCases.AddRange(dangerousCases);
            context.SaveChanges();

            /*var addresses = new Address[]
            {
                new Address{StreetNumber="1",StreetName="Street1",City="Sydney",State="NSW",ZipCode="2000"}, //business 1 address
                new Address{StreetNumber="2",StreetName="Street2",City="Melbourne",State="VIC",ZipCode="3000"},
                new Address{StreetNumber="3",StreetName="Street3",City="Brisbane",State="QLD",ZipCode="4000"}
            };
            context.Addresses.AddRange(addresses);
            context.SaveChanges();*/

            var businesses = new Business[]
            {
                new Business{/*CompanyAddress=addresses[1],*//*CompanyAddress={*/StreetNumber="1",StreetName="Street1",City="Sydney",State="NSW",ZipCode="2000",Name="Big Boss",Phone="8765588888", ABN="12345678999", Email="ff@bb.mm"}
            };
            context.Businesses.AddRange(businesses);
            context.SaveChanges();

            var medicalInstitutions = new MedicalInstitution[]
            {
                new MedicalInstitution{/*CompanyAddress=addresses[1],*//*CompanyAddress={*/StreetNumber="78",StreetName="King",City="Sydney",State="NSW",ZipCode="2005",Name="St.George",Phone="8765588654",Email="mm@mm.mm"}
            };
            context.MedicalInstitutions.AddRange(medicalInstitutions);
            context.SaveChanges();

            var businessActivities = new BusinessActivity[]
            {
                new BusinessActivity{WorkingDate=DateTime.Parse("10/04/2021 2:33:00 PM"),BusinessID=1
                    //VisitorCheckIn = new List<VisitorCheckIn>{visitorCheckIns[0], visitorCheckIns[1]},
                    //VisitorCheckOut = new List<VisitorCheckOut>{ visitorCheckOuts[0], visitorCheckOuts[1]}
                }
            };
            context.BusinessActivities.AddRange(businessActivities);
            context.SaveChanges();

            var visitorCheckIns = new VisitorCheckIn[]
            {
                new VisitorCheckIn{MobilePhone="0490017003",LastName="Zvolinskii",FirstMidName="Dmitrii",Email="dz@zv.zv",BusinessActivityID=1,CheckIn=DateTime.Parse("10/04/2021 2:55:00 AM")},
                new VisitorCheckIn{MobilePhone="0492111119",LastName="Carsos",FirstMidName="Olexander",Email="co@co.com",BusinessActivityID=1,CheckIn=DateTime.Parse("10/04/2021 12:25:00 AM")},
                new VisitorCheckIn{MobilePhone="0492111111",FirstMidName="Carson",LastName="Alexander",Email="ca@ca.ca",BusinessActivityID=1,CheckIn=DateTime.Parse("15/04/2021 1:58:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111112",FirstMidName="Meredith",LastName="Alonso",Email="ma@ma.ma",BusinessActivityID=1,CheckIn=DateTime.Parse("14/04/2021 8:58:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111113",FirstMidName="Arturo",LastName="Anand",Email="aa@aa.aa",BusinessActivityID=1,CheckIn=DateTime.Parse("12/04/2021 10:38:00 AM")},
                new VisitorCheckIn{MobilePhone="0492111114",FirstMidName="Gytis",LastName="Barzdukas",Email="gb@gb.gb",BusinessActivityID=1,CheckIn=DateTime.Parse("11/04/2021 3:15:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111115",FirstMidName="Yan",LastName="Li",Email="yl@yl.yl",BusinessActivityID=1,CheckIn=DateTime.Parse("10/04/2021 6:45:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111116",FirstMidName="Peggy",LastName="Justice",Email="pj@pj.pj",BusinessActivityID=1,CheckIn=DateTime.Parse("15/04/2021 12:22:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111117",FirstMidName="Laura",LastName="Norman",Email="ln@ln.ln",BusinessActivityID=1,CheckIn=DateTime.Parse("11/04/2021 7:45:00 PM")},
                new VisitorCheckIn{MobilePhone="0492111118",FirstMidName="Nino",LastName="Olivetto",Email="no@no.no",BusinessActivityID=1,CheckIn=DateTime.Parse("10/04/2021 1:33:00 PM")}
            };

            context.VisitorsCheckIn.AddRange(visitorCheckIns);
            context.SaveChanges();

            var visitorCheckOuts = new VisitorCheckOut[]
            {
                new VisitorCheckOut{MobilePhone="0490017003",LastName="Zvolinskii",FirstMidName="Dmitrii",Email="dz@zv.zv",BusinessActivityID=1,CheckOut=DateTime.Parse("10/04/2021 4:55:00 AM")},
                new VisitorCheckOut{MobilePhone="0492111119",LastName="Carsos",FirstMidName="Olexander",Email="co@co.com",BusinessActivityID=1,CheckOut=DateTime.Parse("10/04/2021 3:25:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111111",FirstMidName="Carson",LastName="Alexander",Email="ca@ca.ca",BusinessActivityID=1,CheckOut=DateTime.Parse("15/04/2021 3:58:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111112",FirstMidName="Meredith",LastName="Alonso",Email="ma@ma.ma",BusinessActivityID=1,CheckOut=DateTime.Parse("14/04/2021 10:58:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111113",FirstMidName="Arturo",LastName="Anand",Email="aa@aa.aa",BusinessActivityID=1,CheckOut=DateTime.Parse("12/04/2021 11:38:00 AM")},
                new VisitorCheckOut{MobilePhone="0492111114",FirstMidName="Gytis",LastName="Barzdukas",Email="gb@gb.gb",BusinessActivityID=1,CheckOut=DateTime.Parse("11/04/2021 6:15:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111115",FirstMidName="Yan",LastName="Li",Email="yl@yl.yl",BusinessActivityID=1,CheckOut=DateTime.Parse("10/04/2021 8:45:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111116",FirstMidName="Peggy",LastName="Justice",Email="pj@pj.pj",BusinessActivityID=1,CheckOut=DateTime.Parse("15/04/2021 4:22:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111117",FirstMidName="Laura",LastName="Norman",Email="ln@ln.ln",BusinessActivityID=1,CheckOut=DateTime.Parse("11/04/2021 9:45:00 PM")},
                new VisitorCheckOut{MobilePhone="0492111118",FirstMidName="Nino",LastName="Olivetto",Email="no@no.no",BusinessActivityID=1,CheckOut=DateTime.Parse("10/04/2021 2:33:00 PM")}
            };

            context.VisitorsCheckOut.AddRange(visitorCheckOuts);
            context.SaveChanges();

            var patients = new Patient[]
            {
                new Patient{MobilePhone="0490017004",LastName="Zverev",FirstMidName="Daniel",Email="zd@zd.zd",DOB=DateTime.Parse("10/04/1990 12:00:00 AM"), Comment="like to have a vaccination on Tuersday at any time", HadVirus=false},
                new Patient{MobilePhone="0490017005",LastName="Rui",FirstMidName="Li",Email="ru@ru.ru",DOB=DateTime.Parse("3/04/1980 12:00:00 AM"), Comment="like to have a vaccination on Monday at any time", HadVirus=false},
                new Patient{MobilePhone="0490017007",LastName="Smith",FirstMidName="John",Email="sj@sj.sj",DOB=DateTime.Parse("8/06/1980 12:00:00 AM"), Comment="like to have a vaccination on Wednesday at any time", HadVirus=false},
                new Patient{MobilePhone="0490017008",LastName="Green",FirstMidName="Bob",Email="gb@gb.gb",DOB=DateTime.Parse("26/01/1970 12:00:00 AM"), Comment="like to have a vaccination on Thursday at any time", HadVirus=true},
                new Patient{MobilePhone="0490017004",LastName="Demirof",FirstMidName="Leo",Email="dl@dl.dl",DOB=DateTime.Parse("15/07/1960 12:00:00 AM"), Comment="like to have a vaccination on Friday at any time", HadVirus=false},
                new Patient{MobilePhone="0490017009",LastName="Johnson",FirstMidName="Boris",Email="jh@jh.jh",DOB=DateTime.Parse("10/05/1950 12:00:00 AM"), Comment="like to have a vaccination on Saturday at any time", HadVirus=false},
                new Patient{MobilePhone="0490017010",LastName="Zvonorev",FirstMidName="Igor",Email="zi@zi.zi",DOB=DateTime.Parse("20/04/1985 12:00:00 AM"), Comment="like to have a vaccination on Sundat at any time", HadVirus=false}
            };

            context.Patients.AddRange(patients);
            context.SaveChanges();
        }
    }
}