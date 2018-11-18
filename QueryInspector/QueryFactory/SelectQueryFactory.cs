using System.Collections.Generic;
using System.Linq;
using QueryInspector.Models;

namespace QueryInspector.QueryFactory {
	public class SelectQueryFactory {
		public virtual string GenerateQuery(ISelectQuery query) {
			return $"SELECT {GetColumnsClause(query.Columns)}" + GetFromClause(query.Table);
		}

		protected virtual string GetColumnsClause(IReadOnlyList<IColumn> queryColumns) {
			return string.Join(", ", queryColumns.Select(GetColumnClause));
		}

		protected virtual string GetColumnClause(IColumn column) {
			return $"{column.Name}";
		}

		protected virtual string GetFromClause(ITable queryTable) {
			if (queryTable == null) return string.Empty;
			var alias = queryTable.Alias == null ? string.Empty : $" AS {queryTable.Alias}";
			return $" FROM {queryTable.Name}{alias}";
		}
	}
}