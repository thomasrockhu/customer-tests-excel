﻿using CustomerTestsExcel.ExcelToCode;
using System;
using System.Collections.Generic;

namespace CustomerTestsExcel.SpecificationSpecificClassGeneration
{
    public class GivenClassComplexProperty : IGivenClassProperty
    {
        public string Name { get; }
        public string ClassName { get; }
        public ExcelPropertyType Type =>
            ExcelPropertyType.Object;
        // This is a very obvious violation of the liskov substituation principle, and the interface segrgation principle. Not sure what to do about it yet.
        public string ExampleValue =>
            "";

        public GivenClassComplexProperty(string name, string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new System.ArgumentException("name is required", nameof(className));

            if (string.IsNullOrWhiteSpace(name))
                throw new System.ArgumentException("name is required", nameof(className));


            Name = name;
            ClassName = className;
        }

        public bool TypesMatch(Type cSharpPropertytype) =>
            ClassNameMatcher.NamesMatch(cSharpPropertytype.Name, ClassName); // also check for null

        public override string ToString() =>
            $"Name {Name}, Type {Type}, ClassName {ClassName}";

        public override bool Equals(object obj) =>
            obj is GivenClassComplexProperty property
            && Name == property.Name
            && ClassName == property.ClassName;

        public override int GetHashCode()
        {
            var hashCode = 1324288690;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ClassName);
            return hashCode;
        }
    }
}