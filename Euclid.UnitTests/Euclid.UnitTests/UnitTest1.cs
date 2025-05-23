namespace Euclid.UnitTests
{
    [TestFixture]
    public class PointTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorTwoParametersTest()
    {
        //Arrange
        var x = 1;
        var y = 2;

        //Act
        var p = new Point(x, y);

        //Assert
        Assert.That(p.X, Is.EqualTo(x));
        Assert.That(p.Y, Is.EqualTo(y));
    }

    [Test]
    public void ConstructorZeroParametersTest()
    {
        var p = new Point();

        Assert.That(p.X, Is.EqualTo(0));
        Assert.That(p.Y, Is.EqualTo(0));
    }
}
}