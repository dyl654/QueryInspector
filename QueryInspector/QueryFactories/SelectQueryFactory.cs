using QueryInspector.Parsing;

namespace QueryInspector.QueryFactories {
	public class SelectQueryFactory : IQueryFactory {
		public bool CanParseQuery(string sql) {
			var scanner = new TokenScanner(sql);
			var type = scanner.Read();

			return type.LooksLike("select");
		}

		public IQuery ParseQuery(string sql) {
			var scanner = new TokenScanner(sql);
			while (scanner.TokenIsAvailable) {
				if (!scanner.Read().LooksLike("from")) continue;
				
				var next = scanner.Read();
				while (next.IsWhitespace) {
					next = scanner.Read();
				}
				return new SelectQuery {
					Table = next.Contents
				};
			}
			return null;
		}
	}
}