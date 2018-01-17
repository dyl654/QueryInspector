using FluentAssertions;
using NUnit.Framework;

namespace QueryInspector.Test
{
    [TestFixture]
    public class QueryTests
    {
        [Test]
        [Ignore("one day...")]
        public void Sanity() {
            var parser = new QueryParser();
            var query = parser.Parse("select row12 , users.email from users");
            query.GetTableName().Should().Be("users");
        }
    }
}