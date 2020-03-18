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

    using Aspose.Tasks.RiskAnalysis;

    internal class PerformRiskAnalysis
    {
        public static void Run()
        {
            var dataDir = RunExamples.GetDataDir(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName);

            //ExStart:PrepareAnalysisSettings
            //ExFor: RiskAnalysisSettings
            //ExFor: RiskAnalysisSettings.IterationsCount
            //ExSummary: Shows how to prepare risk analysis settings for Monte-Carlo simulations.
            var settings = new RiskAnalysisSettings();

            // Set number of iterations for Monte Carlo simulation (the default value is 100).
            settings.IterationsCount = 200;
            //ExEnd:PrepareAnalysisSettings

            //ExStart:IdentifyAnalysisInput
            var project = new Project(dataDir + "Software Development Plan-1.mpp");
            var task = project.RootTask.Children.GetById(17);

            // Initialize a risk pattern
            var pattern = new RiskPattern(task);

            // Select a distribution type for the random number generator to generate possible values from (only two types currently supported, namely normal and uniform)            
            // For more details see here: https://en.wikipedia.org/wiki/Normal_distribution)
            pattern.Distribution = ProbabilityDistributionType.Normal;

            // Set the percentage of the most likely task duration which can happen in the best possible project scenario 
            // The default value is 75, which means that if the estimated specified task duration is 4 days then the optimistic duration will be 3 days
            pattern.Optimistic = 70;

            // Set the percentage of the most likely task duration which can happen in the worst possible project scenario 
            // The default value is 125, which means that if the estimated specified task duration is 4 days then the pessimistic duration will be 5 days.
            pattern.Pessimistic = 130;

            // Set a confidence level that correspond to the percentage of the time the actual values will be within optimistic and pessimistic estimates. 
            // You can think of it as a value of standard deviation: the more uncertain about your estimates you are, the more the value of standard deviation used in random number generator is
            pattern.ConfidenceLevel = ConfidenceLevel.CL75;
            
            settings.Patterns.Add(pattern);
            //ExEnd:IdentifyAnalysisInput

            //ExStart:AnalyzeRisks
            // Analyze the project risks
            var analyzer = new RiskAnalyzer(settings);
            var analysisResult = analyzer.Analyze(project);
            //ExEnd:AnalyzeRisks

            //ExStart:UseAnalysisResult
            // Select the desired output (here we get early finish of the root task)
            var rootEarlyFinish = analysisResult.GetRiskItems(RiskItemType.EarlyFinish).Get(project.RootTask);

            Console.WriteLine("Expected value: {0}", rootEarlyFinish.ExpectedValue);
            Console.WriteLine("StandardDeviation: {0}", rootEarlyFinish.StandardDeviation);
            Console.WriteLine("10% Percentile: {0}", rootEarlyFinish.GetPercentile(10));
            Console.WriteLine("50% Percentile: {0}", rootEarlyFinish.GetPercentile(50));
            Console.WriteLine("90% Percentile: {0}", rootEarlyFinish.GetPercentile(90));
            Console.WriteLine("Minimum: {0}", rootEarlyFinish.Minimum);
            Console.WriteLine("Maximum: {0}", rootEarlyFinish.Maximum);

            // Save PDF report which is rendered for Project Root Task Finish date
            analysisResult.SaveReport(dataDir + "AnalysisReport_out.pdf");
            //ExEnd:UseAnalysisResult
        }
    }
}
