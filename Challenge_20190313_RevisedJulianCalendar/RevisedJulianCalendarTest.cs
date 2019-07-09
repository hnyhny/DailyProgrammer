using System.Globalization;
using System.Reflection;
using System;
using Xunit;

namespace hnyhny.Challenges.RevisedJulianCalendar
{
    public class RevisedJulianCalendarTest
    {
        [Theory]
        [InlineData(2016, 2017, 1)]
        [InlineData(2019, 2020, 0)]
        [InlineData(1900, 1901, 0)]
        [InlineData(2000, 2001, 1)]
        [InlineData(2800, 2801, 0)]
        [InlineData(123456, 123456, 0)]
        [InlineData(1234, 5678, 1077)]
        [InlineData(123456, 7891011, 1881475)]
        public void TestCountLeapDaysInteger(int startYear, int endYear, int expected)
        {
            var actual = new Calendar().CountLeapDays(startYear, endYear);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2016, 2017, 1)]
        [InlineData(2019, 2020, 0)]
        [InlineData(1900, 1901, 0)]
        [InlineData(2000, 2001, 1)]
        [InlineData(2800, 2801, 0)]
        [InlineData(123456, 123456, 0)]
        [InlineData(1234, 5678, 1077)]
        [InlineData(123456, 7891011, 1881475)]
        [InlineData(123456789101112, 1314151617181920, 288412747246240)]
        public void TestCountLeapDaysUnsignedLong(long startYear, long endYear, long expected)
        {
            var actual = new Calendar().CountLeapDays(startYear, endYear);
            Assert.Equal(expected, actual);
        }

    }
}
