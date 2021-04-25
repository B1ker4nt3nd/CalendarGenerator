using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarGenerator.Model
{
    public class DayModel
    {
        public DayModel(DateTime day, bool? overWriteWithValue = default)
        {
            Day = day;
            IsWorkDay = CalculateWorkday(Day, overWriteWithValue);
        }
        public DateTime Day { get; private set; }
        public bool IsWorkDay { get; private set; }
        private bool CalculateWorkday(DateTime day, bool? overWriteWithValue)
        {
            if (overWriteWithValue != default)
            {
                return (bool)overWriteWithValue;
            }
            return DayIsWorkdayOfWeek(day.DayOfWeek);
        }
        private bool DayIsWorkdayOfWeek(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }
        public string[] ToArray()
        {
            string[] stringArray = new string[] { Day.Year.ToString(), Day.Month.ToString(), Day.Day.ToString(), IsWorkDay.ToString() };

            return stringArray;
        }
    }
}
