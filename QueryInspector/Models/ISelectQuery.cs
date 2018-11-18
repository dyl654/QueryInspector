namespace QueryInspector.Models {
	public interface ISelectQuery {
		ITable Table { get; }
	}
	
	public class SelectQuery : ISelectQuery {
		public ITable Table { get; set; }
	}
}