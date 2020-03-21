/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.WorkingWithFormulas
{
    using System;

    using Aspose.Tasks.Saving;

    internal class WriteFormulasInExtendedAttributesToMPP
    {
        public static void Run()
        {
            try
            {
                var dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);
                
                //ExStart:WriteFormulasInExtendedAttributesToMPP
                //ExFor: ExtendedAttributeDefinition.Formula
                //ExSummary: Shows how to use extended attribute formulas with aliases.
                // Create project instance
                var project = new Project(dataDir + "Project1.mpp");
                project.Set(Prj.NewTasksAreManual, false);

                // Create new custom field (Task Text1) with formula which will double task cost
                var attr = ExtendedAttributeDefinition.CreateTaskDefinition(CustomFieldType.Text, ExtendedAttributeTask.Text1, "Custom");
                attr.Alias = "Double Costs";
                attr.Formula = "[Cost]*2";
                project.ExtendedAttributes.Add(attr);

                // Add a task
                var task = project.RootTask.Children.Add("Task");

                // Set task cost            
                task.Set(Tsk.Cost, 100);

                // Save project
                project.Save(dataDir + "WriteFormulasInExtendedAttributesToMPP_out.mpp", SaveFileFormat.MPP);
                //ExEnd:WriteFormulasInExtendedAttributesToMPP
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.");
            }            
        }
    }
}