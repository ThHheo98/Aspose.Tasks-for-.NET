/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithProjects.WorkingWithProjectProperties
{
    using System;

    using Aspose.Tasks.Saving;

    internal class WriteDefaultProperties
    {
        public static void Run()
        {
            var dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod()); 

            //ExStart:WriteDefaultProperties
            //ExFor: Prj.ScheduleFromStart
            //ExFor: Prj.StartDate
            //ExFor: Prj.DefaultStartTime
            //ExFor: Prj.DefaultTaskType
            //ExFor: Prj.DefaultStandardRate
            //ExFor: Prj.DefaultOvertimeRate
            //ExFor: Prj.DefaultTaskEVMethod
            //ExFor: Prj.DefaultFixedCostAccrual
            //ExSummary: Shows how to write project's default properties.
            // Create a project instance and Set default properties
            var project = new Project();
            project.Set(Prj.ScheduleFromStart, true);
            project.Set(Prj.StartDate, DateTime.Now);
            project.Set(Prj.DefaultStartTime, project.Get(Prj.StartDate));
            project.Set(Prj.DefaultTaskType, TaskType.FixedDuration);
            project.Set(Prj.DefaultStandardRate, 15);
            project.Set(Prj.DefaultOvertimeRate, 12);
            project.Set(Prj.DefaultTaskEVMethod, EarnedValueMethodType.PercentComplete);
            project.Set(Prj.DefaultFixedCostAccrual, CostAccrualType.Prorated);

            // Save the project to XML format
            project.Save(dataDir + "WriteDefaultProperties_out.xml", SaveFileFormat.XML);
            //ExEnd:WriteDefaultProperties
        }
    }
}