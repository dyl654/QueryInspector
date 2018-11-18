namespace QueryInspector {
	public interface ITable {
		string Name { get; }
		string Alias { get; }
	}

	public class Table : ITable {
		public string Name { get; set; }
		public string Alias { get; set; }
	}
}