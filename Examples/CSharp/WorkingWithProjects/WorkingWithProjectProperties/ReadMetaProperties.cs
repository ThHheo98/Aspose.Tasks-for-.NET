﻿namespace Aspose.Tasks.Examples.CSharp.WorkingWithProjects.WorkingWithProjectProperties
{
    using System;

    internal class ReadMetaProperties
    {
        public static void Run()
        {
            // The path to the documents directory.
            var dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            //ExStart:ReadMetaProperties
            // Create a project reader instance
            var project = new Project(dataDir + "ReadProjectInfo.mpp");

            // custom properties are available through the typed collection
            foreach (var property in project.CustomProps)
            {
                Console.WriteLine(property.Type);
                Console.WriteLine(property.Name);
                Console.WriteLine(property.Value);
            }

            // built-in properties are available directly
            Console.WriteLine(project.BuiltInProps.Author);
            Console.WriteLine(project.BuiltInProps.Title);


            // or as an item of built-in property collection
            foreach (var property in project.BuiltInProps)
            {
                Console.WriteLine(property.Name);
                Console.WriteLine(property.Value);
            }
            //ExEnd:ReadMetaProperties
            Console.WriteLine("The program has run successfully");
        }
    }
}