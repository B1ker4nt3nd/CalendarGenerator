using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarGenerator.Model
{
    public class YearModel
    {
        public YearModel(int year, List<DayModel> days)
        {
            Year = year;
            Days = days;
        }
        public int Year { get; set; }
        public List<DayModel> Days { get; set; }
    }
}
