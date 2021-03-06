﻿using CustomerTestsExcel.ExcelToCode;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomerTestsExcel.SpecificationSpecificClassGeneration
{
    public class GivenClassComplexListProperty : IGivenClassProperty
    {
        public string Name { get; }
        public string ClassName { get; }
        public ExcelPropertyType Type =>
            ExcelPropertyType.List;
        // This is a very obvious violation of the liskov substituation principle, and the interface segrgation principle. Not sure what to do about it yet.
        public string ExampleValue =>
            "";

        public GivenClassComplexListProperty(string name, string className)
        {
            if (string.IsNullOrWhiteSpace(className))
                throw new System.ArgumentException("", nameof(className));

            if (string.IsNullOrWhiteSpace(name))
                throw new System.ArgumentException("", nameof(className));

            Name = name;
            ClassName = className;
        }

        public bool TypesMatch(Type cSharpPropertytype)
        {
            return
                typeof(IEnumerable).IsAssignableFrom(cSharpPropertytype)
                && cSharpPropertytype.IsGenericType
                && cSharpPropertytype.GenericTypeArguments.Length == 1
                && ClassNameMatcher.NamesMatch(cSharpPropertytype.GenericTypeArguments[0].Name, ClassName);
        }

        public override string ToString() =>
            $"Name {Name}, Type {Type}, ClassName {ClassName}";

        public override bool Equals(object obj) =>
            obj is GivenClassComplexListProperty property
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