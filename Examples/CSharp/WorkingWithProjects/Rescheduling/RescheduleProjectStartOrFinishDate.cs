using System;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithProjects.Rescheduling
{
    public class RescheduleProjectStartOrFinishDate
    {
        public static void Run()
        {
            //ExStart:RescheduleProjectStartOrFinishDate
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName); 

            Project project = new Project(dataDir + "Project2.mpp");
            project.Set(Prj.ScheduleFromStart, false);
            project.Set(Prj.FinishDate, new DateTime(2020, 1, 1));

            // Now all tasks dates (Start, Finish, EarlyStart, EarlyFinish, LateStart, LateFinish) are calculated. To get the critical path we need to calculate slacks (can be invoked in separate thread, but only after calculation of all early/late dates)
            project.Recalculate();
            TaskCollection criticalPath = project.CriticalPath;
            //ExEnd:RescheduleProjectStartOrFinishDate
        }
    }
}