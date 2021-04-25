using CalendarGenerator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalendarGenerator.BLL.GenerateYearsOfData
{
    public class CreateAYear
    {
        private readonly int Year;
        private readonly List<DifferenceModel> Differences;
        public CreateAYear(int year, List<DifferenceModel> differenceModel)
        {
            Year = year;
            Differences = differenceModel;
        }
        public YearModel Execute()
        {
            var days = EachDay(new DateTime(Year, 1, 1), new DateTime(Year, 12, 31));
            return new YearModel(Year, days.ToList());
        }
        private IEnumerable<DayModel> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            {
                var shouldChange = Differences.Where(x => x.Date == day);
                if (shouldChange.Any())
                {
                    yield return new DayModel(day, shouldChange.First().IsWorkDay);

                }
                else
                {
                    yield return new DayModel(day);
                }
            }
        }

    }
}
