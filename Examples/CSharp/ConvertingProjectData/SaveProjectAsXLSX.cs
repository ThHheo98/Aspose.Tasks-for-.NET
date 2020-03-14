using Aspose.Tasks.Saving;

/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.ConvertingProjectData
{
    public class SaveProjectAsXLSX
    {
        public static void Run()
        {          
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            //ExStart:SaveProjectAsXLSX
            // Read the input Project file
            Project project = new Project(dataDir + "CreateProject2.mpp");

            // Save the Project as XLSX
            project.Save(dataDir + "SaveProjectAsXLSX_out.xlsx", SaveFileFormat.XLSX);
            //ExEnd:SaveProjectAsXLSX           
        }
    }
}