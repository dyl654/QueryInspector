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
			return $"{GetColumnTable(column.Table)}{column.Name}{GetColumnAlias(column)}";
		}

		protected virtual string GetColumnTable(ITable columnTable) {
			if (columnTable == null) return string.Empty;
			return string.IsNullOrEmpty(columnTable.Alias) 
				? $"{columnTable.Name}." 
				: $"{columnTable.Alias}.";
		}

		protected virtual string GetColumnAlias(IColumn column) {
			return string.IsNullOrEmpty(column.Alias)
				? string.Empty
				: $" AS {column.Alias}";
		}

		protected virtual string GetFromClause(ITable queryTable) {
			if (queryTable == null) return string.Empty;
			var alias = queryTable.Alias == null ? string.Empty : $" AS {queryTable.Alias}";
			return $" FROM {queryTable.Name}{alias}";
		}
	}
}