using System.Collections.Generic;
using System.Linq;
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
				Columns = GetColumns(match.Groups[1].Value).ToList(),
				Table = GetTable(match.Groups[3].Value)
			};
		}

		protected virtual IEnumerable<IColumn> GetColumns(string columnList) {
			var columns = columnList.Split(",");
			foreach (var column in columns) {
				yield return new Column {
					Name = column.Trim()
				};
			}
		}

		private static Table GetTable(string table) {
			return new Table {
				Name = table.Trim()
			};
		}
	}
}