using System.Linq;
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

			query.Table.Name.Should().Be("users");
		}
		
		[Test]
		public void CorrectlyIdentifiesColumns() {
			var factory = new SelectQueryFactory();
			var query = factory.ParseQuery("select col1, col2 from users");

			query.Columns.Count().Should().Be(2);
			query.Columns[0].Name.Should().Be("col1");
			query.Columns[1].Name.Should().Be("col2");
		}
	}
}