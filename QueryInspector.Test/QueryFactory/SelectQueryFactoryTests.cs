﻿using FluentAssertions;
using NUnit.Framework;
using QueryInspector.Models;
using QueryInspector.QueryFactory;

namespace QueryInspector.Test.QueryFactory {
	[TestFixture]
	public class SelectQueryFactoryTests {
		[Test]
		public void WhenNoTableIsPresent_ThenFromIsNotGenerated() {
			var factory = new SelectQueryFactory();
			var query = factory.GenerateQuery(new SelectQuery {
				Columns = new []{new Column {Name = "12"}}
			});
			query.Should().Be("SELECT 12");
		}

		[Test]
		public void WhenATableIsPresent_ThenItIsGenerated() {
			var factory = new SelectQueryFactory();
			var query = factory.GenerateQuery(new SelectQuery {
				Columns = new []{new Column {Name = "name"}},
				Table = new Table{Name = "User"}
			});
			query.Should().Be("SELECT name FROM User");
		}

		[Test]
		public void WhenMultipleColumnsArePresent_ThenEachIsGenerated() {
			var factory = new SelectQueryFactory();
			var query = factory.GenerateQuery(new SelectQuery {
				Columns = new [] {
					new Column {Name = "id"},
					new Column {Name = "lastname"}
				},
				Table = new Table{Name = "User"}
			});
			query.Should().Be("SELECT id, lastname FROM User");
		}

		[Test]
		public void WhenATableHasAnAlias_ThenTheAliasIsGenerated() {
			var factory = new SelectQueryFactory();
			var query = factory.GenerateQuery(new SelectQuery {
				Columns = new [] { new Column {Name = "id"} },
				Table = new Table{Name = "User", Alias = "u"}
			});
			query.Should().Be("SELECT id FROM User AS u");
		}
	}
}