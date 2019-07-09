using System;
using System.Linq;

namespace hnyhny.Challenges.RevisedJulianCalendar
{
    internal class Calendar
    {
        internal int CountLeapDays(int startYear, int endYear)
        {
            return Enumerable.Range(startYear, endYear - startYear).Where(HasLeapDay).Count();
        }
        internal long CountLeapDays(long startYear, long endYear)
        {           
            if(startYear == endYear)
                return 0;

            var leapsInIntervall = (endYear - startYear) / 4
            - (endYear - startYear) / 100
            + ((endYear - 200) / 900) - ((startYear - 200) / 900)
            + ((endYear - 600) / 900) - ((startYear - 600) / 900);

            if(HasLeapDay(startYear))
                leapsInIntervall += 1;
            if(endYear - startYear > 900)
                leapsInIntervall += 178;
            return leapsInIntervall;
        }
        private bool HasLeapDay(int year)
        {
            return HasLeapDay((long)year);
        }
        private bool HasLeapDay(long year)
        {
            if (year % 900 == 200 || year % 900 == 600)
                return true;

            if (year % 100 == 0)
                return false;

            if (year % 4 == 0)
                return true;

            return false;
        }
    }
}
