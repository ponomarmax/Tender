using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Tender.DAL.Entities;

namespace Tender.DAL.EF
{
    public class TenderDBInitializer : CreateDatabaseIfNotExists<TenderContext>
    {
        protected override void Seed(TenderContext context)
        {
            Organisation energo = new Organisation { Name = "Energo Atom" };
            Organisation metro = new Organisation { Name = "Kyivsky Metropoliten" };
            Organisation ukr = new Organisation { Name = "UkrEnergo" };
            Organisation zal = new Organisation { Name = "UkrZaliznitsa" };

            Kind opened = new Kind { Name = "Opened" };
            Kind closed = new Kind { Name = "Closed" };
            Kind analyze = new Kind { Name = "Analyze Prises" };

            Currency grivna = new Currency { Name = "Grivna" };
            Currency dollar = new Currency { Name = "Dollar" };
            Currency rubl = new Currency { Name = "Rubl" };

            Classification chem = new Classification { Activity = "Chemical products" };
            Classification clothes = new Classification { Activity = "Clothes and shoes" };
            Classification energy = new Classification { Activity = "Electroenergy, oil  and fuel" };
            Classification print = new Classification { Activity = "Print products" };

            IList<Tend> defaultStandards = new List<Tend>
            {
                new Tend()
                {
                    Name = "Tender 1",
                    Description = "First Standard",
                    Organisator = energo,
                    TenderKind = closed,
                    StartBudget = 1000.5m,
                    Currency = dollar,
                    PublishDate = new DateTime(2018, 12, 12),
                    Classification=chem,
                    GetProposeFromDate = new DateTime(2018, 12, 12),
                    GetProposeToDate = new DateTime(2018, 12, 17)
                },
                new Tend()
                {
                    Name = "Tender 2",
                    Description = "First Standard",
                    Organisator = metro,
                    TenderKind = closed,
                    StartBudget = 2300.5m,
                    Currency = grivna,
                    PublishDate = new DateTime(2017, 12, 12),
                    Classification=clothes,
                    GetProposeFromDate = new DateTime(2017, 12, 12),
                    GetProposeToDate = new DateTime(2017, 12, 17)
                },
                new Tend()
                {
                    Name = "Tender 3",
                    Description = "First Standard",
                    Organisator = energo,
                    TenderKind = opened,
                    StartBudget = 1023.5m,
                    Currency = dollar,
                    PublishDate = new DateTime(2018, 2, 12),
                    Classification=energy,
                    GetProposeFromDate = new DateTime(2018, 2, 12),
                    GetProposeToDate = new DateTime(2018, 2, 17)
                },
                new Tend()
                {
                    Name = "Tender 4",
                    Description = "First Standard",
                    Organisator = zal,
                    TenderKind = opened,
                    StartBudget = 1230.5m,
                    Currency = rubl,
                    PublishDate = new DateTime(2017, 2, 12),
                    Classification=print,
                    GetProposeFromDate = new DateTime(2017, 2, 12),
                    GetProposeToDate = new DateTime(2017, 2, 17)
                },
                new Tend()
                {
                    Name = "Tender 5",
                    Description = "First Standard",
                    Organisator = energo,
                    TenderKind = opened,
                    StartBudget = 230.5m,
                    Currency = dollar,
                    PublishDate = new DateTime(2018, 4, 12),
                    Classification=chem,
                    GetProposeFromDate = new DateTime(2018, 4, 12),
                    GetProposeToDate = new DateTime(2018, 5, 17)
                },
                new Tend()
                {
                    Name = "Tender 6",
                    Description = "First Standard",
                    Organisator = ukr,
                    TenderKind =analyze,
                    StartBudget = 13450.5m,
                    Currency = rubl,
                    PublishDate = new DateTime(2018, 8, 12),
                    Classification=clothes,
                    GetProposeFromDate = new DateTime(2018, 8, 12),
                    GetProposeToDate = new DateTime(2018, 12, 17)

                },
                new Tend()
                {
                    Name = "Tender 7",
                    Description = "First Standard",
                    Organisator = metro,
                    TenderKind = analyze,
                    StartBudget = 1050.5m,
                    Currency = grivna,
                    PublishDate = new DateTime(2018, 9, 12),
                    Classification=energy,
                    GetProposeFromDate = new DateTime(2018, 9, 12),
                    GetProposeToDate = new DateTime(2018, 9, 17)
                },
                new Tend()
                {
                    Name = "Tender 8",
                    Description = "First Standard",
                    Organisator = metro,
                    TenderKind = closed,
                    StartBudget = 200.5m,
                    Currency = dollar,
                    PublishDate = new DateTime(2015, 12, 12),
                    Classification=print,
                    GetProposeFromDate = new DateTime(2015, 12, 12),
                    GetProposeToDate = new DateTime(2018, 9, 17)
                },
                new Tend()
                {
                    Name = "Tender 9",
                    Description = "First Standard",
                    Organisator = ukr,
                    TenderKind = closed,
                    StartBudget = 3330.5m,
                    Currency = grivna,
                    PublishDate = new DateTime(2018, 12, 1),
                    Classification=energy,
                    GetProposeFromDate = new DateTime(2018, 12, 1),
                    GetProposeToDate = new DateTime(2019, 12, 17)
                }
            };

            context.Tenders.AddRange(defaultStandards);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
