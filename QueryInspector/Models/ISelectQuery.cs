using System.Collections.Generic;

namespace QueryInspector.Models {
	public interface ISelectQuery {
		IReadOnlyList<IColumn> Columns { get; }
		ITable Table { get; }
	}
	
	public class SelectQuery : ISelectQuery {
		public IReadOnlyList<IColumn> Columns { get; set; }
		public ITable Table { get; set; }
	}
}