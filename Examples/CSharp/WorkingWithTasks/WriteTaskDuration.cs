﻿/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithTasks
{
    using System;

    using Aspose.Tasks.Saving;

    internal class WriteTaskDuration
    {
        public static void Run()
        {
            var dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod());

            //ExStart:WriteTaskDuration
            //ExFor: Tsk.Duration
            //ExSummary: Shows how to work with a task duration.
            // Create a new project and add a new task
            var project = new Project();
            var task = project.RootTask.Children.Add("Task");

            // Task duration in days (default time unit)
            var duration = task.Get(Tsk.Duration);
            Console.WriteLine("Duration equals 1 day: {0}", duration.ToString().Equals("1 day"));

            // Convert to hours time unit
            duration = duration.Convert(TimeUnitType.Hour);
            Console.WriteLine("Duration equals 8 hrs: {0}", duration.ToString().Equals("8 hrs"));

            // Get wrapped TimeSpan instance
            Console.WriteLine("Duration TimeSpan equals to TimeSpan of 8 hrs: {0}", duration.TimeSpan.Equals(TimeSpan.FromHours(8)));

            // Increase task duration to 1 week and display if duration is updated successfully
            task.Set(Tsk.Duration, project.GetDuration(1, TimeUnitType.Week));
            Console.WriteLine("Duration equals 1 wk: {0}", task.Get(Tsk.Duration).ToString().Equals("1 wk"));

            // Decrease task duration and display if duration is updated successfully
            task.Set(Tsk.Duration, task.Get(Tsk.Duration).Subtract(0.5));
            Console.WriteLine("Duration equals 0.5 wks: {0}", task.Get(Tsk.Duration).ToString().Equals("0.5 wks"));
            //ExEnd:WriteTaskDuration

            // Save project as PDF
            project.Save(dataDir + "WriteTaskDuration_out.pdf", SaveFileFormat.PDF);
        }
    }
}
