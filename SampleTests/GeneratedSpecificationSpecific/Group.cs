using System;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.MethodBase;
using Moq;
using CustomerTestsExcel;
using CustomerTestsExcel.SpecificationSpecificClassGeneration;
using SampleSystemUnderTest;
using SampleTests.IgnoreOnGeneration.AnovaCalculator;
using SampleSystemUnderTest.AnovaCalculator;
using SampleTests.IgnoreOnGeneration.Routing;
using SampleSystemUnderTest.Routing;
using SampleTests.IgnoreOnGeneration.Vermeulen_Near_Wake_Length;
using SampleSystemUnderTest.VermeulenNearWakeLength;
using SampleTests.IgnoreOnGeneration.Calculator;
using SampleSystemUnderTest.Calculator;
using SampleTests.IgnoreOnGeneration.NameConversions;

namespace SampleTests.GeneratedSpecificationSpecific
{
    public class SpecificationSpecificGroup : ReportsSpecificationSetup
    {
        readonly Mock<IGroup> group;

        public IGroup Group =>
            group.Object;

        readonly List<SpecificationSpecificFloat> floatss = new List<SpecificationSpecificFloat>();

        public SpecificationSpecificGroup()
        {
            group = new Mock<IGroup>();

            group.Setup(m => m.Floats).Returns(floatss.Select(l => l.Float));
        }

        internal SpecificationSpecificGroup Name_of(String name)
        {
            valueProperties.Add(GetCurrentMethod(), name);

            group.Setup(m => m.Name).Returns(name);

            return this;
        }




        internal SpecificationSpecificGroup Floats_of(SpecificationSpecificFloat floats)
        {
            classProperties.Add(new ReportSpecificationSetupClass(GetCurrentMethod(), floats));

            this.floatss.Add(floats);

            return this;
        }

        internal SpecificationSpecificGroup Floats_table_of(ReportSpecificationSetupClassUsingTable<SpecificationSpecificFloat> floatss)
        {
            floatss.PropertyName = GetCurrentMethod().Name;

            classTableProperties.Add(floatss);

            foreach (var row in floatss.Rows)
                this.floatss.Add(row.Properties);

            return this;
        }
    }
}