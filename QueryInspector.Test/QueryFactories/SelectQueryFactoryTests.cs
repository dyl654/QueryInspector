using FluentAssertions;
using NUnit.Framework;
using QueryInspector.QueryFactories;

namespace QueryInspector.Test.QueryFactories {
	[TestFixture]
	public class SelectQueryFactoryTests {
		[Test]
		public void CanParseSqlThatBeginsWithSelect() {
			var factory = new SelectQueryFactory();
			factory.CanParseQuery("select 1").Should().BeTrue();
		}

		[Test]
		public void CorrectlyIdentifiesTable() {
			var factory = new SelectQueryFactory();
			var query = factory.ParseQuery("select * from users");

			query.Should().Be("users");
		}
	}
}