namespace TinyNetSession.ConsoleApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var a = 1;
            Assert.Pass();
            a.Should().Be(1);
        }
    }
}