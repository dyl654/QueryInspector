using FluentAssertions;
using NUnit.Framework;

namespace QueryInspector.Test
{
    [TestFixture]
    public class QueryTests
    {
        [Test]
        public void Sanity() {
            var parser = new QueryParser();
            var query = parser.Parse("select * from users");
            query.GetTableName().Should().Be("users");
        }
    }
}