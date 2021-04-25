using System;

namespace CalendarGenerator.Model
{
    public class DifferenceModel
    {
        public long Index { get; set; }
        //public short Year { get; set; }
        //public short Month { get; set; }
        //public short Day { get; set; }
        public bool IsWorkDay { get; set; }
        //public DateTime Date { get { return new DateTime(Year, Month, Day); } }
        public DateTime Date { get; set; }
    }
}
