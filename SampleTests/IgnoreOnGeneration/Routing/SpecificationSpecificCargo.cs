﻿using Moq;
using CustomerTestsExcel;
using static System.Reflection.MethodBase;
using SampleSystemUnderTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleSystemUnderTest.Routing;

namespace SampleTests.IgnoreOnGeneration.Routing
{
    public class SpecificationSpecificCargo : ReportsSpecificationSetup
    {
        readonly Mock<ICargo> _cargo;

        public SpecificationSpecificCargo()
            : base()
        {
            _cargo = new Mock<ICargo>();
            _cargo.Setup(m => m.ItineraryLegs).Returns(_legs.Select(l => l.Leg));
        }

        public ICargo Cargo => _cargo.Object;

        public SpecificationSpecificCargo Origin_of(string origin)
        {
            valueProperties.Add(GetCurrentMethod(), origin);
            _cargo.Setup(m => m.Origin).Returns(origin);
            return this;
        }

        public SpecificationSpecificCargo Destination_of(string destination)
        {
            valueProperties.Add(GetCurrentMethod(), destination);
            _cargo.Setup(m => m.Destination).Returns(destination);
            return this;
        }

        readonly List<SpecificationSpecificItineraryLeg> _legs = new List<SpecificationSpecificItineraryLeg>();
        public SpecificationSpecificCargo ItineraryLeg_of(SpecificationSpecificItineraryLeg leg)
        {
            classProperties.Add(new ReportSpecificationSetupClass(GetCurrentMethod(), leg, true, _legs.Count));

            _legs.Add(leg);

            return this;
        }

        public SpecificationSpecificCargo ItineraryLeg_table_of(ReportSpecificationSetupClassUsingTable<SpecificationSpecificItineraryLeg> legs)
        {
            legs.PropertyName = GetCurrentMethod().Name;

            classTableProperties.Add(legs);

            foreach (var row in legs.Rows)
                _legs.Add(row.Properties);

            return this;
        }

    }
}
