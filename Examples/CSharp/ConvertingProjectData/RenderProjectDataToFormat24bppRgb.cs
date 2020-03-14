using System.Drawing.Imaging;
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
    public class RenderProjectDataToFormat24bppRgb
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            //ExStart:RenderProjectDataToFormat24bppRgb
            Project project = new Project(dataDir + "TestProject1.mpp");
            ImageSaveOptions options = new ImageSaveOptions(SaveFileFormat.TIFF);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;
            options.PixelFormat = PixelFormat.Format24bppRgb;
            project.Save(dataDir + "RenderProjectDataToFormat24bppRgb_out.tif", options);
            //ExEnd:RenderProjectDataToFormat24bppRgb
        }
    }
}