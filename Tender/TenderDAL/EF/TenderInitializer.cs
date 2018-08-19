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
            Classification energy = new Classification { Activity = "Energy, Power and Electrical , Infrastructure and construction" };
            Classification print = new Classification { Activity = "Print products" };

            IList<Tend> defaultStandards = new List<Tend>
            {
                new Tend()
                {
                    Name = "Home Elevation Construction Services",
                    Description = "Computer Hardware Software, Printers For The Office Of Humanitarian Policy Of The Liubeshiv Village Council",
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
                    Name = "Hire of engineering consultant",
                    Description = "Digital Media – Online Elearning Curriculum And Virtual Support Group",
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
                    Name = "Developmental of Wassaic Center",
                    Description = "Ehr/rcm - Integrated Electronic Health Records Andrevenue Cycle Management System",
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
                    Name = "Work of IHP Porch Cooling",
                    Description = "Recreation Management Software & Support",
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
                    Name = "	Infrastructure and construction",
                    Description = "Machines For Data Processing (hardware) - By Code - (interactive Panel Multimedia Board)",
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
                    Name = "Ports,Waterways and Shipping",
                    Description = "Department Of Transportation (dot), And Department Of General Services (dgs) Are Seeking Software Functionality Details From Highly Qualified Vendors. The City Is Seeking A Replacement For The Current",
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
                    Name = "Mental Health Furniture",
                    Description = "	Automated/automatic Door Maintenance, Repair, And Inspection",
                    Organisator = metro,
                    TenderKind = analyze,
                    StartBudget = 1050.5m,
                    Currency = grivna,
                    PublishDate = new DateTime(2018, 9, 12),
                    Classification=chem,
                    GetProposeFromDate = new DateTime(2018, 9, 12),
                    GetProposeToDate = new DateTime(2018, 9, 17)
                },
                new Tend()
                {
                    Name = "E-learning Platform",
                    Description = "	3-d Printers, Laptop, Calibration Panels For 3d Printer, Dual Camera Upgrade Kit, Automatic Turn Table, Scan Level Pro, And Router",
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
                    Name = "Data Compilation And Analysis",
                    Description = "Technical Proposal For Network System Services And Price Proposal For Network System Services",
                    Organisator = ukr,
                    TenderKind = closed,
                    StartBudget = 3330.5m,
                    Currency = grivna,
                    PublishDate = new DateTime(2018, 12, 1),
                    Classification=energy,
                    GetProposeFromDate = new DateTime(2018, 12, 1),
                    GetProposeToDate = new DateTime(2019, 12, 17)
                },
                new Tend()
                {
                    Name = "Supply Of Kyocera",
                    Description = "Supplying Of 01 (one)no. Of Lenovo Laptop With Following Configurations:-i.proccssor: Intel Core I5-7200u.7.generation",
                    Organisator = zal,
                    TenderKind = analyze,
                    StartBudget = 3120.5m,
                    Currency = rubl,
                    PublishDate = new DateTime(2018, 12, 1),
                    Classification=clothes,
                    GetProposeFromDate = new DateTime(2018, 12, 1),
                    GetProposeToDate = new DateTime(2019, 12, 17)
                },
                new Tend()
                {
                    Name = "Software Services",
                    Description = "Supply Of Computer, Network And Software For The Needs Of The State Higher Vocational School Witelona In Legnica",
                    Organisator = ukr,
                    TenderKind = opened,
                    StartBudget = 31111.5m,
                    Currency = grivna,
                    PublishDate = new DateTime(2018, 12, 1),
                    Classification=energy,
                    GetProposeFromDate = new DateTime(2018, 12, 1),
                    GetProposeToDate = new DateTime(2019, 12, 17)
                },
                new Tend()
                {
                    Name = "Tender Notice",
                    Description = "Only Online Offers Are Admitted, Detail And Image Of Boots Are Attached. Queries Veronica Da Silva / Tel: 2708-90-79 Dnppf Credit Siif 60 Days Immediate Delivery",
                    Organisator = metro,
                    TenderKind = analyze,
                    StartBudget = 130.5m,
                    Currency = dollar,
                    PublishDate = new DateTime(2018, 12, 1),
                    Classification=chem,
                    GetProposeFromDate = new DateTime(2018, 12, 1),
                    GetProposeToDate = new DateTime(2019, 12, 17)
                },
                new Tend()
                {
                    Name = "GIS/ GPS",
                    Description = "Research, Engineering, Designing, Developing, Integrating, Transferring Data, Testing And Authoring Software And Application Systems And Maintaining (within The Warranty Period) Of The E-learning Syst",
                    Organisator = ukr,
                    TenderKind = closed,
                    StartBudget = 3330.5m,
                    Currency = grivna,
                    PublishDate = new DateTime(2018, 12, 1),
                    Classification=print,
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
