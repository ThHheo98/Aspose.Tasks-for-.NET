﻿/*
This project uses Automatic Package Restore feature of NuGet to resolve Aspose.Tasks for .NET API reference 
when the project is build. Please check https:// Docs.nuget.org/consume/nuget-faq for more information. 
If you do not wish to use NuGet, you can manually download Aspose.Tasks for .NET API from https://www.nuget.org/packages/Aspose.Tasks/, 
install it and then add its reference to this project. For any issues, questions or suggestions 
please feel free to contact us using https://forum.aspose.com/c/tasks
*/

namespace Aspose.Tasks.Examples.CSharp.Miscellaneous
{
    using System;

    using Aspose.Tasks.Saving;

    internal class WriteMetadataToMPP
    {
        public static void Run()
        {
            try
            {
                var dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);
                
                //ExStart:WriteMetadataToMPP
                //ExFor: Tsk.Contact
                //ExFor: Rsc.Group
                //ExFor: Rsc.EMailAddress
                //ExFor: Rsc.WindowsUserAccount
                //ExSummary: Shows how to prepare and save project with metadata were set for main entities (Tasks, Resources, Assignments).
                var project = new Project(dataDir + "Project1.mpp");

                // Add working times to project calendar
                var wt = new WorkingTime();
                wt.FromTime = new DateTime(2010, 1, 1, 19, 0, 0);
                wt.ToTime = new DateTime(2010, 1, 1, 20, 0, 0);
                var day = project.Get(Prj.Calendar).WeekDays.ToList()[1];
                day.WorkingTimes.Add(wt);

                // Change calendar name
                project.Get(Prj.Calendar).Name = "CHANGED NAME!";

                // Add tasks and set task meta data
                var task = project.RootTask.Children.Add("Task 1");
                task.Set(Tsk.DurationFormat, TimeUnitType.Day);
                task.Set(Tsk.Duration, project.GetDuration(3));
                task.Set(Tsk.Contact, "Rsc 1");
                task.Set(Tsk.IsMarked, true);
                task.Set(Tsk.IgnoreWarnings, true);
                var task2 = project.RootTask.Children.Add("Task 2");
                task2.Set(Tsk.DurationFormat, TimeUnitType.Day);
                task2.Set(Tsk.Contact, "Rsc 2");

                // Link tasks
                project.TaskLinks.Add(task, task2, TaskLinkType.FinishToStart, project.GetDuration(-1, TimeUnitType.Day));

                // Set project start date
                project.Set(Prj.StartDate, new DateTime(2013, 8, 13, 9, 0, 0));

                // Add resource and set resource meta data
                var rsc1 = project.Resources.Add("Rsc 1");
                rsc1.Set(Rsc.Type, ResourceType.Work);
                rsc1.Set(Rsc.Initials, "WR");
                rsc1.Set(Rsc.AccrueAt, CostAccrualType.Prorated);
                rsc1.Set(Rsc.MaxUnits, 1);
                rsc1.Set(Rsc.Code, "Code 1");
                rsc1.Set(Rsc.Group, "Workers");
                rsc1.Set(Rsc.EMailAddress, "1@gmail.com");
                rsc1.Set(Rsc.WindowsUserAccount, "user_acc1");
                rsc1.Set(Rsc.IsGeneric, new NullableBool(true));
                rsc1.Set(Rsc.AccrueAt, CostAccrualType.End);
                rsc1.Set(Rsc.StandardRate, 10);
                rsc1.Set(Rsc.StandardRateFormat, RateFormatType.Day);
                rsc1.Set(Rsc.OvertimeRate, 15);
                rsc1.Set(Rsc.OvertimeRateFormat, RateFormatType.Hour);

                rsc1.Set(Rsc.IsTeamAssignmentPool, true);
                rsc1.Set(Rsc.CostCenter, "Cost Center 1");

                // Create resource assignment and set resource assignment meta data
                var assn = project.ResourceAssignments.Add(task, rsc1);
                assn.Set(Asn.Uid, 1);
                assn.Set(Asn.Work, task.Get(Tsk.Duration));
                assn.Set(Asn.RemainingWork, assn.Get(Asn.Work));
                assn.Set(Asn.RegularWork, assn.Get(Asn.Work));
                task.Set(Tsk.Work, assn.Get(Asn.Work));

                rsc1.Set(Rsc.Work, task.Get(Tsk.Work));
                assn.Set(Asn.Start, task.Get(Tsk.Start));
                assn.Set(Asn.Finish, task.Get(Tsk.Finish));

                // Add extended attribute for project and task
                var attributeDefinition = ExtendedAttributeDefinition.CreateTaskDefinition(CustomFieldType.Flag, ExtendedAttributeTask.Flag1,  "My Flag Field");
                project.ExtendedAttributes.Add(attributeDefinition);

                var attribute = attributeDefinition.CreateExtendedAttribute();
                attribute.FlagValue = true;
                task2.ExtendedAttributes.Add(attribute);

                // Save project as MPP
                project.Save(dataDir + "WriteMetaData_out.mpp", SaveFileFormat.MPP);
                //ExEnd:WriteMetadataToMPP
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nThis example will only work if you apply a valid Aspose License. You can purchase full license or get 30 day temporary license from http://www.aspose.com/purchase/default.aspx.");
            }
        }
    }
}
