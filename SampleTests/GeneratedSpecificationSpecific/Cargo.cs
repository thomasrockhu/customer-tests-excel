using System;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.MethodBase;
using Moq;
using CustomerTestsExcel;
using CustomerTestsExcel.SpecificationSpecificClassGeneration;
using SampleSystemUnderTest;
using SampleSystemUnderTest.AnovaCalculator;
using SampleSystemUnderTest.Routing;
using SampleSystemUnderTest.VermeulenNearWakeLength;
using SampleSystemUnderTest.Calculator;

namespace SampleTests.GeneratedSpecificationSpecific
{
    public partial class SpecificationSpecificCargo : ReportsSpecificationSetup
    {
        readonly Mock<ICargo> cargo;

        public ICargo Cargo =>
            cargo.Object;

        readonly List<SpecificationSpecificItineraryLeg> itineraryLegs = new List<SpecificationSpecificItineraryLeg>();

        public SpecificationSpecificCargo()
        {
            cargo = new Mock<ICargo>();

            cargo.Setup(m => m.ItineraryLeg).Returns(itineraryLegs.Select(l => l.ItineraryLeg));
        }



        internal SpecificationSpecificCargo Origin_of(String origin)
        {
            AddValueProperty(GetCurrentMethod(), origin);

            cargo.Setup(m => m.Origin).Returns(origin);

            return this;
        }

        internal SpecificationSpecificCargo Destination_of(String destination)
        {
            AddValueProperty(GetCurrentMethod(), destination);

            cargo.Setup(m => m.Destination).Returns(destination);

            return this;
        }




        internal SpecificationSpecificCargo ItineraryLeg_of(SpecificationSpecificItineraryLeg itineraryLeg)
        {
            AddClassProperty(new ReportSpecificationSetupClass(GetCurrentMethod(), itineraryLeg));

            this.itineraryLegs.Add(itineraryLeg);

            return this;
        }

        internal SpecificationSpecificCargo ItineraryLeg_table_of(ReportSpecificationSetupClassUsingTable<SpecificationSpecificItineraryLeg> itineraryLegs)
        {
            itineraryLegs.PropertyName = GetCurrentMethod().Name;

            AddClassTableProperty(itineraryLegs);

            foreach (var row in itineraryLegs.Rows)
                this.itineraryLegs.Add(row.Properties);

            return this;
        }
    }
}
