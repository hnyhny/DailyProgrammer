using System.Linq;

namespace hnyhny.Challenges.RevisedJulianCalendar
{
    internal class Calendar
    {
        internal int CountLeapDays(int startYear, int endYear)
        {
            return Enumerable.Range(startYear, endYear - startYear).Where(HasLeapDay).Count();
        }

        private bool HasLeapDay(int year)
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
