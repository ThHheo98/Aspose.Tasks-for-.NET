/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithProjects.WorkingWithProjectViews
{
    using System;
    using System.Drawing;

    using Aspose.Tasks.Saving;

    internal class ConfigureGanttChart
    {
        public static void Run()
        {
            try
            {
                // The path to the documents directory.
                var dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

                //ExStart:ConfigureGanttChart
                var project = new Project(dataDir + "Project5.mpp"); // Create a new project task
                var task = project.RootTask.Children.Add("New Activity");

                // Define new custom attribute
                var text1Definition = ExtendedAttributeDefinition.CreateTaskDefinition(ExtendedAttributeTask.Text1, null);
                project.ExtendedAttributes.Add(text1Definition);
                // Add custom text attribute to created task.
                task.ExtendedAttributes.Add(text1Definition.CreateExtendedAttribute("Activity attribute"));

                // Customize table by adding text attribute field
                var attrField = new TableField();
                attrField.Field = Field.TaskText1;
                attrField.Width = 20;
                attrField.Title = "Custom attribute";
                attrField.AlignTitle = StringAlignment.Center;
                attrField.AlignData = StringAlignment.Center;

                var table = project.Tables.ToList()[0];
                table.TableFields.Insert(3, attrField);

                project.Save(dataDir + @"ConfigureGantChart_out.mpp", new MPPSaveOptions { WriteViewData = true });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http:// Www.aspose.com/purchase/default.aspx.");
            }
            //ExEnd:ConfigureGanttChart
        }
    }
}