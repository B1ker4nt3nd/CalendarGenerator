using CalendarGenerator.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CalendarGenerator.BLL.ReadInput
{
    public class ReadInputCsv
    {
        private readonly string FilePath;
        public ReadInputCsv(string filePath)
        {
            Regex rgx = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$");
            
            //rgx.IsMatch(filePath)
            if (string.IsNullOrWhiteSpace(filePath) || !rgx.IsMatch(filePath))
            {
                throw new Exception("Filepath not valid");
            }

            if (!File.Exists(filePath))
            {
                throw new Exception("File does not exist.");
            }
            FilePath = filePath;
        }

        public List<DifferenceModel> ExecuteRead()
        {
            var lines = File.ReadLines(FilePath).Select(a => a.Split(';'));

            var index = 0;
            var differences = new List<DifferenceModel>();
            foreach (var line in lines)
            {
                if (index == 0)
                {
                    index++;
                    continue;
                }

                var values = line[0].Split(",");

                short.TryParse(values[0], out var year);
                short.TryParse(values[1], out var month);
                short.TryParse(values[2], out var day);
                bool.TryParse(values[3], out var isWorkDay);

                differences.Add(new DifferenceModel()
                {
                    Index = index,
                    //Year = year,
                    //Month = month,
                    //Day = day,
                    Date = new DateTime(year, month, day),
                    IsWorkDay = isWorkDay
                });
                index++;
            }

            return differences;
        }
    }
}
