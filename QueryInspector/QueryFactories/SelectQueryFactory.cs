using System.Collections.Generic;
using System.Text.RegularExpressions;
using QueryInspector.Models;

namespace QueryInspector.QueryFactories {
	public class SelectQueryFactory : IQueryFactory {
		private readonly Regex _selectStatement = new Regex(@"^select(.*?)(from(.*))?$");
		
		public bool CanParseQuery(string sql) {
			return _selectStatement.IsMatch(sql);
		}

		public ISelectQuery ParseQuery(string sql) {
			var match = _selectStatement.Match(sql);
			return new SelectQuery {
				Columns = GetColumns(match.Groups[1].Value),
				Table = GetTable(match.Groups[3].Value)
			};
		}

		private static Table GetTable(string table) {
			return new Table {
				Name = table.Trim()
			};
		}

		protected virtual IEnumerable<IColumn> GetColumns(string columns) {
			yield return new Column {
				Name = columns.Trim()
			};
		}
	}
}