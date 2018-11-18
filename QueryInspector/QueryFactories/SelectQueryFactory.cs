using System.Collections.Generic;
using System.Text.RegularExpressions;
using QueryInspector.Models;

namespace QueryInspector.QueryFactories {
	public class SelectQueryFactory : IQueryFactory {
		private readonly Regex _selectStatement = new Regex(@"^select(.*)from(.*)$");
		public bool CanParseQuery(string sql) {
			return _selectStatement.IsMatch(sql);
		}

		public ISelectQuery ParseQuery(string sql) {
			var match = _selectStatement.Match(sql);
			var table = match.Groups[2].Value;
			var columns = GetColumns(match.Groups[1].Value);
			return new SelectQuery {
				Columns = columns,
				Table = new Table {
					Name = table
				}
			};
		}

		protected virtual IEnumerable<IColumn> GetColumns(string columns) {
			yield return new Column {
				Name = columns
			};
		}
	}
}