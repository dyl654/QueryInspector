namespace QueryInspector {
	public interface IQueryFactory {
		bool CanParseQuery(string sql);
		IQuery ParseQuery(string sql);
	}
}