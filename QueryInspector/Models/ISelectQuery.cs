using System.Collections.Generic;

namespace QueryInspector.Models {
	public interface ISelectQuery {
		IEnumerable<IColumn> Columns { get; }
		ITable Table { get; }
	}
	
	public class SelectQuery : ISelectQuery {
		public IEnumerable<IColumn> Columns { get; set; }
		public ITable Table { get; set; }
	}
}