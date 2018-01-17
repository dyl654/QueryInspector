using FluentAssertions;
using NUnit.Framework;

namespace QueryInspector.Test
{
    [TestFixture]
    public class QueryTests
    {
        [Test]
        public void Sanity() {
            1.Should().Be(1);
        }
    }
}