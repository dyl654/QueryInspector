using QueryInspector.Parsing;

namespace QueryInspector.QueryFactories {
	public class SelectQueryFactory : IQueryFactory {
		public bool CanParseQuery(string sql) {
			var scanner = new TokenScanner(sql);
			var type = scanner.Read();

			return type.LooksLike("select");
		}

		public IQuery ParseQuery(string sql) {
			throw new System.NotImplementedException();
		}
	}
}