﻿using Aspose.Tasks.Visualization;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.Miscellaneous
{
    class SaveBestPracticeAnalyzerReport
    {
        public static void Run()
        {
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            //ExStart:SaveBestPracticeAnalyzerReport
            Project project1 = new Project(dataDir + "Cyclic stucture.mpp");
            project1.SaveReport(dataDir + "BestPracticeAnalyzer_out.pdf", ReportType.BestPracticeAnalyzer);
            //ExEnd:SaveBestPracticeAnalyzerReport
        }
    }
}
