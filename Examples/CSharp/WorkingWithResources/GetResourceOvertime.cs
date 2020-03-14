﻿using System;

namespace Aspose.Tasks.Examples.CSharp.WorkingWithResources
{
    class GetResourceOvertime
    {
        public static void Run()
        {
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            //ExStart:GetResourceOvertime
            // Create project instance
            Project project1 = new Project(dataDir + "ResourceOvertime.mpp");

            // Display overtime related parameters for all resources
            foreach (Resource res in project1.Resources)
            {
                if (res.Get(Rsc.Name) == null)
                {
                    continue;
                }

                Console.WriteLine(res.Get(Rsc.OvertimeCost));
                Console.WriteLine(res.Get(Rsc.OvertimeWork).ToString());
                Console.WriteLine(res.Get(Rsc.OvertimeRateFormat).ToString());
            }
            //ExEnd:GetResourceOvertime
        }
    }
}
