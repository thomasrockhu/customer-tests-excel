﻿using CustomerTestsExcel;
using SampleSystemUnderTest.VermeulenNearWakeLength;
using System;

namespace SampleTests.IgnoreOnGeneration.Vermeulen_Near_Wake_Length
{
    internal class SpecificationSpecificTurbineGeometry : ReportsSpecificationSetup, ITurbineGeometry
    {
        public int NumberOfBlades { get; private set; }
        public double Diameter_m { get; private set; }

        internal SpecificationSpecificTurbineGeometry NumberOfBlades_of(int numberOfBlades)
        {
            _valueProperties.Add(System.Reflection.MethodBase.GetCurrentMethod().Name, numberOfBlades);

            NumberOfBlades = numberOfBlades;

            return this;
        }

        internal SpecificationSpecificTurbineGeometry Diameter_of(double diameter_m)
        {
            _valueProperties.Add(System.Reflection.MethodBase.GetCurrentMethod().Name, diameter_m);

            Diameter_m = diameter_m;

            return this;
        }
    }
}