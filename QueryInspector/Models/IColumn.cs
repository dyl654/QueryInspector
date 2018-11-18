namespace QueryInspector.Models {
	public interface IColumn {
		string Name { get; }
		string Alias { get; }
		ITable Table { get; }
	}

	public class Column : IColumn {
		public string Name { get; set; }
		public string Alias { get; set; }
		public ITable Table { get; set; }
	}
}