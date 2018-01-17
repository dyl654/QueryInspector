using FluentAssertions;
using NUnit.Framework;

namespace QueryInspector.Test
{
    [TestFixture]
    public class QueryTests
    {
        [Test]
        [Ignore("Needs factory implementation first")]
        public void BasicSelectTest() {
            var parser = new QueryParser();
            var query = parser.Parse("select row12 , users.email from users");
            query.Table.Should().Be("users");
        }
    }
}