﻿using System;

using Aspose.Tasks.Util;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithTasks
{
    class ReadTaskCalendar
    {
        public static void Run()
        {
            //ExStart:ReadTaskCalendar
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            // Create project instance
            Project prj = new Project(dataDir + "ReadTaskCalendar.mpp");

            // Declare ChildTasksCollector class object
            ChildTasksCollector collector = new ChildTasksCollector();

            // Use TaskUtils to get all children tasks in RootTask
            TaskUtils.Apply(prj.RootTask, collector, 0);

            // Parse all the recursive children
            foreach (Task tsk in collector.Tasks)
            {
                Calendar tskCal = tsk.Get(Tsk.Calendar);
                Console.WriteLine("Task calendar name: {0}", tskCal == null ? "None" : tskCal.Name);
            }
            //ExEnd:ReadTaskCalendar
        }
    }
}
