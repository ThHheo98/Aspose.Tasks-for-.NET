﻿using Aspose.Tasks.Saving;
using Aspose.Tasks.Visualization;
using System;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithTasks.WorkingWithTaskConstraints
{
    class SetConstraintMustStartOn
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            // Create project instance
            Project project1 = new Project(dataDir + "ConstraintMustStartOn.mpp");

            //ExStart:SetConstraintMustStartOn
            // Set constraint Must Start On for task with Id 5
            Task roof = project1.RootTask.Children.GetById(5);
            roof.Set(Tsk.ConstraintType, ConstraintType.MustStartOn);
            roof.Set(Tsk.ConstraintDate, new DateTime(2017, 1, 1, 9, 0, 0));
                        
            // Save project as pdf
            SaveOptions options = new PdfSaveOptions();
            options.StartDate = project1.Get(Prj.StartDate);
            options.Timescale = Timescale.ThirdsOfMonths;
            project1.Save(dataDir + "project_MustStartOn_out.pdf", options);
            //ExEnd:SetConstraintMustStartOn
        }
    }
}
