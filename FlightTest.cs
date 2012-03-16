using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        DateTime startDate = new DateTime(2010, 1, 1, 12, 0, 0);
        DateTime endDate = new DateTime(2010, 1, 10, 12, 0, 0);
        int miles = 10000;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(endDate, startDate, miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(startDate, endDate, -5);
        }

        [Test()]
        public void TestThatPriceIsCorrect()
        {
            var target = new Flight(startDate, endDate, miles);
            Assert.AreEqual(target.getBasePrice(), 200+20*9);
        }
	}
}
