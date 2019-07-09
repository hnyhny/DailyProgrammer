using System;
using System.Linq;

namespace hnyhny.Challenges.RevisedJulianCalendar
{
    internal class Calendar
    {
        internal long CountLeapDays(long startYear, long endYear)
        {
            var difference = endYear - startYear;

            if (difference == 1 && HasLeapDay(startYear))
                return 1;

            if (difference <= 1)
                return 0;

            return CountClosedIntervals(difference, 4)
            - CountClosedIntervals(difference, 100)
            + CountClosedIntervals(startYear, endYear, 900, 600)
            + CountClosedIntervals(startYear, endYear, 900, 200)
            ;
        }

        private long CountClosedIntervals(long number, int length)
        {
            return number / length;
        }

        private long CountClosedIntervals(long intervalStart, long intervalEnd, int length, int offset)
        {
            return (intervalEnd - offset) / length - (intervalStart - offset) / length;
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
