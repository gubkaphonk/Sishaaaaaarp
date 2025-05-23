using System.Drawing;

namespace Euclid.UnitTests
{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void CreateSegment_TwoDifferentPoints_Segment()
        {
            var a = new Point(1, 1);
            var b = new Point(2, 3);

            var s = Geometry.CreateSegment(a, b);

            Assert.That(s.A, Is.EqualTo(a));
            Assert.That(s.B, Is.EqualTo(b));
        }

        [Test]
        public void CreateSegment_TwoEqualPoints_ArgumentExeption()
        {
            var a = new Point(2, 3);
            var b = new Point(2, 3);

            //Assert.That(() => Geometry.CreateSegment(a, b), Throws.ArgumentException);

            var exception = Assert.Throws<ArgumentException>(() => Geometry.CreateSegment(a, b));

            Assert.That(exception.Message, Is.EqualTo("Концы отрезка совпадают"));
        }


        [TestCase(1, 1, true)]
        [TestCase(2, 3, true)]
        [TestCase(1.5, 2, true)]
        [TestCase(1, 2, false)]
        [TestCase(0, -1, false)]
        [TestCase(3, 5, false)]
        public void IsPointInsideSegmentTest(double pX, double pY, bool result)
        {
            var a = new Point(1, 1);
            var b = new Point(2, 3);
            var s = new Segment(a, b);

            var p = new Point(pX, pY);

            Assert.That(Geometry.IsPointInsideSegment(p, s), Is.EqualTo(result));
        }
    }
}