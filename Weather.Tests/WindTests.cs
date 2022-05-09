using NUnit.Framework;
using Weather.Library;

namespace Weather.Tests
{
    public class WindTests
    {
        private Wind wind;

        [SetUp]
        public void SetUp()
        {
            wind = new Wind
            {
                Deg = 0,
                Speed = 0,
                Gust = 0.0m
            };
        }

        [Test]
        [TestCase(11, "North by Northeast")]
        [TestCase(33, "North by Northeast")]
        [TestCase(34, "Northeast")]
        [TestCase(55, "Northeast")]
        [TestCase(56, "East by Northeast")]
        [TestCase(78, "East by Northeast")]
        [TestCase(79, "East")]
        [TestCase(100, "East")]
        [TestCase(101, "East by Southeast")]
        [TestCase(123, "East by Southeast")]
        [TestCase(124, "Southeast")]
        [TestCase(145, "Southeast")]
        [TestCase(146, "South by Southeast")]
        [TestCase(168, "South by Southeast")]
        [TestCase(169, "South")]
        [TestCase(190, "South")]
        [TestCase(191, "South by Southwest")]
        [TestCase(213, "South by Southwest")]
        [TestCase(214, "Southwest")]
        [TestCase(235, "Southwest")]
        [TestCase(236, "West by Southwest")]
        [TestCase(258, "West by Southwest")]
        [TestCase(259, "West")]
        [TestCase(280, "West")]
        [TestCase(281, "West by Northwest")]
        [TestCase(303, "West by Northwest")]
        [TestCase(304, "Northwest")]
        [TestCase(325, "Northwest")]
        [TestCase(326, "North by Northwest")]
        [TestCase(326, "North by Northwest")]
        [TestCase(349, "North")]
        [TestCase(0, "North")]
        [TestCase(360, "North")]
        public void DegreesReturnCorrectly(int degrees, string direction)
        {
            //Arrange
            wind.Deg = degrees;
            //Act
            string answer = wind.Direction();
            //Assert
            Assert.AreEqual(direction, answer);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(361)]
        public void DegreeErrorsReturnCorrectly(int degreesError)
        {
            //Arrange
            wind.Deg = degreesError;

            //Act
            string answer = wind.Direction();
            //Assert
            Assert.AreEqual("Error in Degrees", answer);
        }
    }
}