﻿using Aspose.Tasks.Saving;
using System;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithTasks
{
    class CreateSubProjectTask
    {
        public static void Run()
        {
            try
            {
                //ExStart:CreateSubProjectTask
                // Create project instance
                string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);
                Project project = new Project(dataDir + "SubProjectTask.mpp");

                // Add task
                Task task = project.RootTask.Children.Add("Task 1");

                // Setting new subproject link
                task.Set(Tsk.SubprojectName, dataDir + "subProject.mpp");

                // Save project
                project.Save(dataDir + "SubProjectTask_out.mpp", SaveFileFormat.MPP);
                //ExEnd:CreateSubProjectTask
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose.Tasks License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.");
            }
        }
    }
}
