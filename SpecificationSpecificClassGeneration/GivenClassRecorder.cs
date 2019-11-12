﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerTestsExcel.ExcelToCode;
using NUnit.Framework;

namespace CustomerTestsExcel.SpecificationSpecificClassGeneration
{
    public class GivenClassMutable
    {
        public string Name { get; set; }
        public List<IGivenClassProperty> Properties { get; set; } = new List<IGivenClassProperty>();

        public GivenClassMutable(string name)
        {
            Name = name;
        }
    }

    public class GivenClassRecorder : IExcelToCodeVisitor
    {
        readonly List<GivenClassMutable> classes = new List<GivenClassMutable>();
        public IReadOnlyList<GivenClass> Classes =>
            classes.Select(mutableClass => new GivenClass(mutableClass.Name, mutableClass.Properties)).ToList();

        readonly Stack<GivenClassMutable> currentClasses = new Stack<GivenClassMutable>();

        public void VisitGivenComplexPropertyDeclaration(IGivenComplexProperty givenComplexProperty)
        {
            AddPropertyToCurrentClass(
                new GivenClassComplexProperty(
                    givenComplexProperty.PropertyName,
                    givenComplexProperty.ClassName));

            CreateOrActivateCurrentClass(givenComplexProperty.ClassName);
        }

        public void VisitGivenComplexPropertyFinalisation() =>
            FinishCurrentClass();

        public void VisitGivenSimpleProperty(IGivenSimpleProperty givenSimpleProperty)
        {
            AddPropertyToCurrentClass(
                new GivenClassSimpleProperty(
                    givenSimpleProperty.PropertyOrFunctionName,
                    givenSimpleProperty.ExcelPropertyType));
        }

        public void VisitGivenListPropertyDeclaration(IGivenListProperty givenListProperty)
        {
            AddPropertyToCurrentClass(
                new GivenClassComplexListProperty(
                    givenListProperty.PropertyName,
                    givenListProperty.ClassName));

            CreateOrActivateCurrentClass(givenListProperty.ClassName);
        }

        public void VisitGivenListPropertyFinalisation() =>
            FinishCurrentClass();

        public void VisitGivenTablePropertyDeclaration(IGivenTableProperty givenTableProperty, IEnumerable<TableHeader> tableHeaders)
        {
            AddPropertyToCurrentClass(
                new GivenClassComplexListProperty(
                    givenTableProperty.PropertyName,
                    givenTableProperty.ClassName));

            CreateOrActivateCurrentClass(givenTableProperty.ClassName);
        }

        public void VisitGivenTablePropertyFinalisation() =>
            FinishCurrentClass();

        public void VisitGivenTablePropertyRowDeclaration(uint row)
        {
            // don't need to do anything special with table rows
        }

        public void VisitGivenTablePropertyRowFinalisation()
        {
            // don't need to do anything special with table rows
        }

        public void VisitGivenTablePropertyCellDeclaration(TableHeader tableHeader, uint row, uint column)
        {
            // don't need to do anything special with table cells
        }

        public void VisitGivenTablePropertyCellFinalisation()
        {
            // don't need to do anything special with table cells
        }

        void AddPropertyToCurrentClass(IGivenClassProperty givenClassProperty)
        {
            if (currentClasses.Any())
                currentClasses.Peek().Properties.Add(givenClassProperty);
        }

        void CreateOrActivateCurrentClass(string className)
        {
            // The same class might be set up twice (2 items in a list for example). 
            // So want to put it back on the stack if so.
            // This doesn't consider classes that have a property of their own class
            // but we could handle this is we wanted to by looking at the stack for
            // the class and adding it again to the top of the stack. I think.
            if (classes.Any(c => c.Name == className))
                currentClasses.Push(classes.Single(c => c.Name == className));
            else
                currentClasses.Push(new GivenClassMutable(className));
        }

        void FinishCurrentClass() =>
            classes.Add(currentClasses.Pop());

    }
}