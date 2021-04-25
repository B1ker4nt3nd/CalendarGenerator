using CalendarGenerator.BLL.GenerateYearsOfData;
using CalendarGenerator.BLL.ReadInput;
using CalendarGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CalendarGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var sourcePath = args[0];
            var executer = new ReadInputCsv(sourcePath);
            var differences = executer.ExecuteRead();
            //var years = differences.Select(x => x.Year).Distinct();
            var years = differences.GroupBy(x => x.Date.Year);

            var calculatedYears = new List<YearModel>();

            foreach (var year in years)
            {
                var yearCalculator = new CreateAYear(year.Key, year.ToList());

                calculatedYears.Add(yearCalculator.Execute());
                //var yearCalculator = new CreateAYear(yearNumber, differences.Where(x => x.Year == yearNumber).ToList());
            }
            var resultFolderPath = args[1];
            var resultDirectoryInfo = Directory.CreateDirectory(resultFolderPath);
            
            foreach (var calculatedYear in calculatedYears)
            {
                var resultFilePath = @$"{resultDirectoryInfo.FullName}\{calculatedYear.Year}_{DateTime.Now:yyyy_MM_dd_HH_mm_ss}.csv";
                using (var tw = new StreamWriter(resultFilePath, true))
                {
                    foreach (var day in calculatedYear.Days)
                    {
                        tw.WriteLine(string.Join(",", day.ToArray()));
                    }
                }
            }

            Console.WriteLine("Done");
        }
    }
}
