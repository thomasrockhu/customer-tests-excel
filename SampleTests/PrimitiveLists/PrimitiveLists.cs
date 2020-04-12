using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CustomerTestsExcel;
using CustomerTestsExcel.Assertions;
using CustomerTestsExcel.SpecificationSpecificClassGeneration;
using System.Linq.Expressions;
using SampleTests;
using SampleTests.GeneratedSpecificationSpecific;

using SampleSystemUnderTest;
using SampleSystemUnderTest.AnovaCalculator;
using SampleSystemUnderTest.Routing;
using SampleSystemUnderTest.VermeulenNearWakeLength;
using SampleSystemUnderTest.Calculator;

namespace SampleTests.PrimitiveLists
{
    [TestFixture]
    public class PrimitiveLists : SpecificationBase<SpecificationSpecificObjectWithPrimiiveLists>, ISpecification<SpecificationSpecificObjectWithPrimiiveLists>
    {
        public override string Description()
        {
            return "Primtive lists are supported";
        }
        
        // arrange
        public override SpecificationSpecificObjectWithPrimiiveLists Given()
        {
            var objectWithPrimiiveLists = new SpecificationSpecificObjectWithPrimiiveLists();
            {
                var IntegerTableSyntaxRow = new ReportSpecificationSetupClassUsingTable<SpecificationSpecificInteger>();
                {
                    var integerTableSyntaxRow = new SpecificationSpecificInteger();
                    integerTableSyntaxRow.Integer_of(1);
                    IntegerTableSyntaxRow.Add(integerTableSyntaxRow);
                }
                {
                    var integerTableSyntaxRow = new SpecificationSpecificInteger();
                    integerTableSyntaxRow.Integer_of(2);
                    IntegerTableSyntaxRow.Add(integerTableSyntaxRow);
                }
                objectWithPrimiiveLists.IntegerTableSyntax_table_of(IntegerTableSyntaxRow);
            }
            {
                var FloatTableSyntaxRow = new ReportSpecificationSetupClassUsingTable<SpecificationSpecificFloat>();
                {
                    var floatTableSyntaxRow = new SpecificationSpecificFloat();
                    floatTableSyntaxRow.Float_of(1.1);
                    FloatTableSyntaxRow.Add(floatTableSyntaxRow);
                }
                {
                    var floatTableSyntaxRow = new SpecificationSpecificFloat();
                    floatTableSyntaxRow.Float_of(2.2);
                    FloatTableSyntaxRow.Add(floatTableSyntaxRow);
                }
                objectWithPrimiiveLists.FloatTableSyntax_table_of(FloatTableSyntaxRow);
            }
            {
                var StringTableSyntaxRow = new ReportSpecificationSetupClassUsingTable<SpecificationSpecificString>();
                {
                    var stringTableSyntaxRow = new SpecificationSpecificString();
                    stringTableSyntaxRow.String_of("s1");
                    StringTableSyntaxRow.Add(stringTableSyntaxRow);
                }
                {
                    var stringTableSyntaxRow = new SpecificationSpecificString();
                    stringTableSyntaxRow.String_of("s2");
                    StringTableSyntaxRow.Add(stringTableSyntaxRow);
                }
                objectWithPrimiiveLists.StringTableSyntax_table_of(StringTableSyntaxRow);
            }
            
            return objectWithPrimiiveLists;
        }
        
        public override string When(SpecificationSpecificObjectWithPrimiiveLists objectWithPrimiiveLists)
        {
            objectWithPrimiiveLists.Do_Nothing();
            return "Do Nothing";
        }
        
        public override IEnumerable<IAssertion<SpecificationSpecificObjectWithPrimiiveLists>> Assertions()
        {
            return new List<IAssertion<SpecificationSpecificObjectWithPrimiiveLists>>
            {
                  new EqualityAssertion<SpecificationSpecificObjectWithPrimiiveLists>(objectWithPrimiiveLists => objectWithPrimiiveLists.Result, 1)
            };
        }
        
        protected override string AssertionClassPrefixAddedByGenerator => "I";
    }
}
